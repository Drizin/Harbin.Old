using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Harbin.Common.TypeSafeEnums
{
    // TODO: Replace by other popular TypeSafeEnum library?
    // https://github.com/HeadspringLabs/Enumeration
    // https://github.com/ardalis/SmartEnum
    // https://ardalis.com/listing-strongly-typed-enum-options-in-c

    #region TypeSafeEnum<TSE, U>
    /// <summary>
    /// Type Safe Enums ("Class Enums" or "Smart Enums") that can be serialized/deserialized into POCO classes properties.
    /// Type <typeparamref name="U"/> is the underlying CLR type for the key, defined in POCO class.
    /// Type <typeparamref name="TSE"/> is the base type for the Type Safe Enum.
    /// This base class enforces singleton behavior for each different possible key (<typeparamref name="U"/> key) in this type <typeparamref name="TSE" />.
    /// </summary>
    /// <typeparam name="U">Underlying CLR type of the identifier (if Key in POCO is string, int, Guid, etc)</typeparam>
    /// <typeparam name="TSE">Base type that is implementing the Type-Safe-Enum. 
    /// If each enum value has a different class then should use the common superclass (e.g. both AccountingManagerContactTypeEnum and AssistantSalesAgentContactTypeEnum should use ContactTypeEnum as <typeparamref name="TSE"/>)</typeparam>
    public abstract class TypeSafeEnum<TSE, U>
        where TSE : TypeSafeEnum<TSE, U>
        where U : IEquatable<U>, IComparable<U>
    {
        static TypeSafeEnum()
        {
            TypeSafeDapper.RegisterDapperConverter(typeof(TSE));
        }
        private readonly U _key;
        //[NotMapped]
        public U Key { get { return this._key; } }


        /// <summary>
        /// Tracks all instances of the underlying type <typeparamref name="TSE"/>.
        /// </summary>
        // ensures that no two values use the same underlying key, since each TSE will have it's own independent dictionary
        private static Dictionary<U, TSE> enumValues = new Dictionary<U, TSE>();

        /// <summary>
        /// All possible Values for this Type-Safe Enum <typeparamref name="TSE"/>
        /// </summary>
        public static IEnumerable<TSE> Values { get { return enumValues.Select(x => x.Value); } }

        /// <summary>
        /// All possible underlying Keys for this Type-Safe Enum <typeparamref name="TSE"/>
        /// </summary>
        public static IEnumerable<U> Keys { get { return enumValues.Select(x => x.Key); } }

        public TypeSafeEnum(U key)
        {
            this._key = key;
            enumValues.Add(key, (TSE)(object)this);
        }

        public static TSE FromKey(U key) 
        {
            // ensure static constructor was executed, so that we'll have all enum values (instances) created and mapped
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(TSE).TypeHandle); 

            if (!enumValues.ContainsKey(key))
                throw new Exception(string.Format("EnumValue {0} not found for type {1}", key, typeof(TSE).Name));
            return enumValues[key]; //we could also dynamically load by reflection looking for types that are immediate children of T
        }

        // Instead of reference equals, test value equality, just in case the factory is somehow bypassed.
        public static bool operator ==(TypeSafeEnum<TSE, U> a, TypeSafeEnum<TSE, U> b)
        {
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            var typeMatches = a.GetType().Equals(b.GetType());
            var valueMatches = a.Key.Equals(b.Key);

            return typeMatches && valueMatches;
        }

        public static bool operator !=(TypeSafeEnum<TSE, U> a, TypeSafeEnum<TSE, U> b)
        {
            return !(a == b);
        }

        public static implicit operator U(TypeSafeEnum<TSE, U> smartEnum) =>
            smartEnum.Key;

        public static explicit operator TypeSafeEnum<TSE, U>(U value) =>
            FromKey(value);

        public virtual int CompareTo(TypeSafeEnum<TSE, U> other) =>
            Key.CompareTo(other.Key);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(TypeSafeEnum<TSE, U>)) return false;
            return Equals((TypeSafeEnum<TSE, U>)obj);
        }

        public bool Equals(TypeSafeEnum<TSE, U> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Key, this.Key);
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode() ^ typeof(TSE).FullName.GetHashCode();
        }

        public override string ToString()
        {
            Type instanceType = this.GetType();
            Type enumType = typeof(TSE);
            if (instanceType == enumType)
                return $"{enumType.Name} (key={this.Key.ToString()})";
            else
                return $"{enumType.Name} (key={this.Key.ToString()} / {instanceType.Name})";
        }

        public static IEnumerable<TSE> GetEnumValues()
        {
            // ensure static constructor was executed, so that we'll have all enum values (instances) created and mapped
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(TSE).TypeHandle);

            // Get all the registered enum values from the dictionary TypeSafeEnum<S, string>.Values
            var gt = typeof(TypeSafeEnum<,>);
            var makeme = gt.MakeGenericType(new Type[] { typeof(TSE), typeof(U) });
            var allEnumsProperty = makeme.GetProperties().Where(x => x.Name == "Values").SingleOrDefault();
            var enumValues = allEnumsProperty.GetValue(null, null);
            return enumValues as IEnumerable<TSE>;
        }


        /// <summary>
        /// For an entity <typeparamref name="E"/> and an Type-Safe-Enum property (<typeparamref name="TSE"/>), returns the Name of the underlying property.
        /// </summary>
        /// <typeparam name="E">Entity with the Type-Safe-Enum (must specify since the Type-Safe-Enum does NOT have a reference to the container class)</typeparam>
        /// <param name="propertySelector">Selector for Type-Safe-Enum</param>
        /// <returns>Name of underlying type</returns>
        public static string UnderlyingPropertyName<E>(Expression<Func<E, TSE>> propertySelector)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(E));
            PropertyInfo property = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;

            //var attribute = property.GetCustomAttribute(typeof(TypeSafeEnumAttribute)) as TypeSafeEnumAttribute; // why doesn't this work?
            var attribute = typeof(E).GetProperty(property.Name).GetCustomAttribute(typeof(TypeSafeEnumWrapperAttribute)) as TypeSafeEnumWrapperAttribute;
            if (attribute == null)
                throw new ArgumentNullException(string.Format("Property {0}.{1} must have attribute {2}", typeof(E).Name, property.Name, typeof(TypeSafeEnumWrapperAttribute).Name)); //return "_statusKey";
            return attribute.UnderlyingProperty;
        }

        /// <summary>
        /// For an entity <typeparamref name="E"/> and a property of type <typeparamref name="TSE"/>, returns the PropertyInfo for the underlying property of <typeparamref name="TSE"/>.
        /// </summary>
        /// <typeparam name="E">Entity with the Type-Safe-Enum (must specify since the Type-Safe-Enum does NOT have a reference to the container class)</typeparam>
        /// <param name="propertySelector">Selector for Type-Safe-Enum</param>
        /// <returns>PropertyInfo of underlying type</returns>
        public static PropertyInfo UnderlyingProperty<E>(Expression<Func<E, TSE>> propertySelector)
        {
            var underlyingPropertyName = UnderlyingPropertyName<E>(propertySelector);
            var underlyingProperty = typeof(E).GetProperties().Where(x => x.Name == underlyingPropertyName).SingleOrDefault();
            if (underlyingProperty == null)
                throw new ArgumentNullException(string.Format("Property {0}.{1} doesn't exist", typeof(E).Name, underlyingProperty.Name));
            return underlyingProperty;
        }
    }
    #endregion
}
