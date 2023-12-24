using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersianAssistant.Models;

namespace PersianAssistant.Extensions
{ 
    public static class ResponseManager
    {
        public static ServiceMessage ServerError()
        {
            return new ServiceMessage()
            {
                ErrorId = -1,
                ErrorTitle = "خطای سیستمی رخ داده، مجددا تلاش کنید.",
            };
        }
        public static ServiceMessage ServerError(string error)
        {
            return new ServiceMessage()
            {
                ErrorId = -1,
                ErrorTitle = error,
            };
        }

        public static ServiceMessage SessionExpire()
        {
            return new ServiceMessage()
            {
                ErrorId = -21,
                ErrorTitle = "مدت زمان مجاز شما برای حضور در نرم افزار به پایان رسیده است لطفا مجددا وارد شوید.",
            };
        }
        public static ServiceMessage SessionExpire(string error)
        {
            return new ServiceMessage()
            {
                ErrorId = -21,
                ErrorTitle = error,
            };
        }

        public static ServiceMessage DataError(string title)
        {
            return new ServiceMessage()
            {
                ErrorId = -2,
                ErrorTitle = title,
            };
        }
        public static ServiceMessage FillObject(dynamic obj)
        {
            return new ServiceMessage()
            {
                ErrorId = 0,
                Result = obj
            };
        }    
        public static ServiceMessage CustomResponse(int id, string title, dynamic res)
        {
            return new ServiceMessage()
            {
                ErrorId = id,
                ErrorTitle = title,
                Result = res
            };
        }


    } 
}