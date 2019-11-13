using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Harbin.Common.TypeSafeEnums
{
    public class TypeSafeDapper
    {
        public static void RegisterDapperConverters(Assembly assembly)
        {
            var typeSafeEnums = assembly.GetTopLevelTypeSafeEnums().ToList(); // TypeSafeEnums except their derived subtypes

            foreach (var typeSafeEnum in typeSafeEnums)
                RegisterDapperConverter(typeSafeEnum);
        }
        /// <summary>
        /// Given a Type-Safe-Enum TSE{TSE, U}, this will register a DapperConverter for that TSE:
        /// This is a dynamic way of calling Dapper.SqlMapper.AddTypeHandler(new TypeSafeEnumDapperConverter{TSE, U}());
        /// </summary>
        /// <param name="typeSafeEnumType"></param>
        public static void RegisterDapperConverter(Type typeSafeEnumType)
        {
            if (!TypeSafeEnumHelper.IsTopLevelTypeSafeEnum(typeSafeEnumType))
                throw new Exception("RegisterDapperConverter should be used only for TypeSafeEnum types");

            //Dapper.SqlMapper.AddTypeHandler(new TypeSafeEnumDapperConverter<ContactTypeEnum, int>());
           var keyType = typeSafeEnumType.BaseType.GetGenericArguments()[1];

            var gt = typeof(TypeSafeEnumDapperConverter<,>);
            var makeme = gt.MakeGenericType(new Type[] { typeSafeEnumType, keyType });
            object mapper = Activator.CreateInstance(makeme); // new TypeSafeEnumDapperConverter<ContactTypeEnum, int>()

            var method = typeof(Dapper.SqlMapper).GetMethods().Where(x => x.Name == "AddTypeHandler" && x.GetParameters().Length == 1).SingleOrDefault(); //TODO: check on type
            var generic = method.MakeGenericMethod(new Type[] { typeSafeEnumType }); // Dapper.SqlMapper.AddTypeHandler<ContactTypeEnum>(...)
            generic.Invoke(null, new[] { mapper }); // Dapper.SqlMapper.AddTypeHandler(new TypeSafeEnumDapperConverter<ContactTypeEnum>());

            //System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(enumType.TypeHandle); // Force initialization of enum classes
        }


        #region TypeSafeEnumDapperConverter<TSE, U>
        //https://github.com/StackExchange/Dapper/issues/259
        /// <summary>
        /// Configures Dapper to correctly map from <typeparamref name="U"/> key (underlying CLR type) to <typeparamref name="TSE"/> value and vice-versa.
        /// </summary>
        /// <typeparam name="TSE"></typeparam>
        /// <typeparam name="U"></typeparam>
        protected class TypeSafeEnumDapperConverter<TSE, U> : Dapper.SqlMapper.TypeHandler<TSE>
            where TSE : TypeSafeEnum<TSE, U>
        {
            public override TSE Parse(object value)
            {
                return TypeSafeEnum<TSE, U>.FromKey((U)value); // we can't use ITypeSafeEnum because FromKey is a static factory (can't be defined in interface)
            }
            public override void SetValue(IDbDataParameter parameter, TSE value)
            {
                if (typeof(U) == typeof(string))
                {
                    parameter.DbType = System.Data.DbType.AnsiString;
                    parameter.Size = 64; //status = varchar(64)
                    parameter.Value = value.Key;
                }
                if (typeof(U) == typeof(int))
                {
                    parameter.DbType = System.Data.DbType.Int32;
                    parameter.Value = value.Key;
                }
                if (typeof(U) == typeof(short))
                {
                    parameter.DbType = System.Data.DbType.Int16;
                    parameter.Value = value.Key;
                }
                if (typeof(U) == typeof(Guid))
                {
                    parameter.DbType = System.Data.DbType.Guid;
                    parameter.Value = value.Key;
                }
            }
        }
        #endregion
    }
}
