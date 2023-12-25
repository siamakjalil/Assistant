# This asistant helps PERSIAN developers...

We have lots of conversions in this package that are explained in blow : 

## CurrencyExtension: 
It has some methods that convert number to Persian currency type.

example : 
```
1000.Rial() ==> 1,000 ریال
1000.Toman() ==> 1,000 تومان
```

## DateExtension: 
It's convert date to persianDate or vice versa...
Methods:
```
ToPersianDate(DateTime value) 
ToPersianDateTime(DateTime value)
DayOfWeekPersianTitle(DayOfWeek day) // example : DayOfWeekPersianTitle(DayOfWeek.Saturday) ==> "شنبه"
DayOfWeekPersianIndex(DayOfWeek day) // example : DayOfWeekPersianIndex(DayOfWeek.Saturday) ==> 1
PersianDayTitleByIndex(int index) // example : PersianDayTitleByIndex(1) ==> "شنبه"
PersianDaysDropDown()
IsPersianDayValidInMonth(int month, int day) // check valid day number in month
PersianMonthTitleByIndex(int month) // example : PersianMonthTitleByIndex(1) ==> "فروردین"
PersianDateToDate(string dateStr) // convert persian date to valid date 
PersianDateToDateTime(string dateStr)
StartAndEndOfMonth(DateTime dateTime)
BeginEndOfMonthAsPersian(DateTime dateTime)
GetPersianYear(DateTime value)
GetPersianDay(DateTime value)
GetPersianMonth(DateTime value)
GetYearList(int from, int to) // as persian year 
GetMonthList() // as number 
GetDayList() // as number 
GetDateInfo(DateTime? enterDate) // ==> شنبه 21 شهریور 1402
NotificationDateTimeStringFormat(DateTime dateTime) // one signal date format 
```

## NumberExtension
This method workes with number : 
```
ToIranMobileNumber(string mobileNumber) // => 09121112233
ToEnglishNumber(string number) // example : ToEnglishNumber("١") ==> 1
ToPersianNumber(string number) // example : ToEnglishNumber("1") ==> ١
GenerateCode(int length) // generate random code by length
CheckIranNationalCode(string nationalCode)
IsDigitsOnly(string str)
NumberDropDown(int val) // get list from 1 to your val
Round1000(double? val) // example : Round1000(15999) ==> 16000
```

## PasswordExtensions
It is the most valuable extension for hashing password with salt : 
```
GeneratePasswordSalt(int length) // at first you must generate salt by your length.
EncodePassword(string pass, string salt) // after creating salt you must encode your password.
```

## PageExtension
It's for paging and return PageModel :
```
Paging(this int pageId, int count , int take) 

public class PageModel
    {
        public int Skip { get; set; }
        public int PageCount { get; set; }
        public int Take { get; set; }
    }
```

## GenderExtension
It's for user gender in persian :
```
GetGenderVal(int value) // ==> مرد / زن
GetGenderId(string value) // ==> 1 , 2
GenderList()
```

## ResponseManager
It's a good response for your api or any other methods that are return json : 
```
SessionExpire(string error) // errorId = -21
DataError(string title) // errorId = -2
FillObject(dynamic obj) // errorId = 0 , it's a success method , you can pass any object.
CustomResponse(int id, string title, dynamic res) // with this method you can create your custom response and errorId.
```

## TimeExtension
This method works with time :
```
ToTime(DateTime time)
ToIntTime(this DateTime time) // return array from hour and minute
TimeDifference(DateTime dateTime, int difference)
```

## StatusExtension
It's for user status : 
```
StatusList()
GetStatusVal(int value) // example : GetStatusVal(1) ==> فعال
```

## OtherExtensions
```
KafYePersian(string input) // convert  ک و ی arabic to persian
IsValidEmail(string email)
```