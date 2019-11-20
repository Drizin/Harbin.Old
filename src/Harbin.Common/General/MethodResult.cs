using System;
using System.Collections.Generic;
using System.Text;

namespace Harbin.Common
{
    #region BaseMethodResult<R>
    /// <summary>
    /// Returns the result of a method that does NOT output any entity, but may or may not return SUCCESS
    /// If your method doesn't return anything, just use void, no need to use MethodResult
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public abstract class BaseMethodResult<R> where R : struct, IComparable, IConvertible, IFormattable // R should be enum. 
    {
        #region Members
        public string Message { get; set; }
        public R ResultCode { get; set; }
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Returns the Last occurred Exception, if any. 
        /// Only used if we're swallowing (ignoring) exceptions intentionally.
        /// Please note that expected errors should NOT be returned as exceptions, but rather as enums.
        /// </summary>
        public Exception LastException { get; private set; }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return (this.IsSuccess ? "Success: " : "Error: ") + this.ResultCode.ToString() + (this.Message != null ? " - " + this.Message : "");
        }
        #endregion
    }
    #endregion

    #region ResultCodeEnum: SUCCESS / ERROR only
    /// <summary>
    /// Generic enum for operations which return either Success or Error.
    /// </summary>
    public enum ResultCodeEnum
    {
        SUCCESS,
        ERROR
    }
    #endregion

    #region MethodResult<R> - Returns the result of a method that does NOT output any entity
    /// <summary>
    /// Returns the result of a method that does NOT output any entity
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public class MethodResult<R> : BaseMethodResult<R> where R : struct, IComparable, IConvertible, IFormattable // R should be enum. 
    {
        #region ctor
        public static MethodResult<R> CreateError(R resultCode, string message)
        {
            return new MethodResult<R>() { IsSuccess = false, ResultCode = resultCode, Message = message };
        }
        public static MethodResult<R> CreateSuccess(R resultCode, string message = "Success")
        {
            return new MethodResult<R>() { IsSuccess = true, ResultCode = resultCode, Message = message };
        }
        #endregion
    }
    public class MethodResult : MethodResult<ResultCodeEnum> 
    {
        #region ctor
        public static MethodResult<ResultCodeEnum> CreateError(string message)
        {
            return new MethodResult<ResultCodeEnum>() { IsSuccess = false, ResultCode = ResultCodeEnum.ERROR, Message = message };
        }
        public static MethodResult<ResultCodeEnum> CreateSuccess(string message = "Success")
        {
            return new MethodResult<ResultCodeEnum>() { IsSuccess = true, ResultCode = ResultCodeEnum.SUCCESS, Message = message };
        }
        #endregion
    }
    #endregion

    #region MethodResult<R, T> - Returns the result of a method that DOES output entity of type T
    /// <summary>
    /// Returns the result of a method that DOES output entity of type T
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class MethodResult<R, T> : BaseMethodResult<R> where R : struct, IComparable, IConvertible, IFormattable // R should be enum. 
    {
        public T Entity { get; internal set; }

        #region ctor
        public static MethodResult<R, T> CreateError(R resultCode, string message)
        {
            return new MethodResult<R, T>() { IsSuccess = false, ResultCode = resultCode, Message = message };
        }
        public static MethodResult<R, T> CreateSuccess(R resultCode, T entity, string message = "Success")
        {
            return new MethodResult<R, T>() { IsSuccess = true, ResultCode = resultCode, Entity = entity, Message = message };
        }
        #endregion

    }
    #endregion


    /// <summary>
    /// Returns the result of a method that outputs a LIST of entities of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="R"></typeparam>
    public class MethodListResult<R, T> : BaseMethodResult<R> where R : struct, IComparable, IConvertible, IFormattable // R should be enum. 
    {
        public List<T> Entities { get; internal set; }
        #region ctor
        public static MethodListResult<R, T> CreateError(R resultCode, string message)
        {
            return new MethodListResult<R, T>() { IsSuccess = false, ResultCode = resultCode, Message = message };
        }
        public static MethodListResult<R, T> CreateSuccess(R resultCode, List<T> entities, string message = "Success")
        {
            return new MethodListResult<R, T>() { IsSuccess = true, ResultCode = resultCode, Entities = entities, Message = message };
        }
        #endregion
    }
}
