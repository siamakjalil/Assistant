using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assistant.Models;

namespace Assistant.Extensions
{ 
    public static class ResponseManagerExtension
    {
        public static ServiceMessageModel ServerError()
        {
            return new ServiceMessageModel()
            {
                ErrorId = -1,
                ErrorTitle = "خطای سیستمی رخ داده، مجددا تلاش کنید.",
            };
        }
        public static ServiceMessageModel ServerError(string error)
        {
            return new ServiceMessageModel()
            {
                ErrorId = -1,
                ErrorTitle = error,
            };
        }

        public static ServiceMessageModel SessionExpire()
        {
            return new ServiceMessageModel()
            {
                ErrorId = -21,
                ErrorTitle = "مدت زمان مجاز شما برای حضور در نرم افزار به پایان رسیده است لطفا مجددا وارد شوید.",
            };
        }
        public static ServiceMessageModel SessionExpire(string error)
        {
            return new ServiceMessageModel()
            {
                ErrorId = -21,
                ErrorTitle = error,
            };
        }

        public static ServiceMessageModel DataError(string title)
        {
            return new ServiceMessageModel()
            {
                ErrorId = -2,
                ErrorTitle = title,
            };
        }
        public static ServiceMessageModel FillObject(dynamic obj)
        {
            return new ServiceMessageModel()
            {
                ErrorId = 0,
                Result = obj
            };
        }    
        public static ServiceMessageModel CustomResponse(int id, string title, dynamic res)
        {
            return new ServiceMessageModel()
            {
                ErrorId = id,
                ErrorTitle = title,
                Result = res
            };
        }


    } 
}