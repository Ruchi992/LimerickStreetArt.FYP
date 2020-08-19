//using Plugin.Settings;
//using Plugin.Settings.Abstractions;
//using System;


//namespace LimerickStreetArt.MobileForms.Helper
//{
//    class AppSetting

//    {
//        private static ISettings AppSettings
//        {
//            get
//            {
//                return CrossSettings.Current;
//            }
//        }
//        public static string Username
//        {
//            get
//            {
//                return AppSettings.GetValueOrDefaul<string>("Username", "");

//            }
//            set
//            {
//                AppSettings.AddOrUpdateValue<string>("Username", value);
//            }
//        }
//        public static string Password
//        {
//            get
//            {
//                return AppSettings.GetValueOrDefault<string>("Password", "");
//            }
//            set
//            {
//                AppSettings.AddOrUpdateValue<string>("Password", value);
//            }
//        }
//        public static string AccessToken
//        {
//            get
//            {
//                return AppSettings.GetValueOrDefault<string>("AccessToken", "");
//            }
//            set
//            {
//                AppSettings.AddOrUpdateValue<string>("AccessToken", value);
//            }
//        }

//        public static DateTime AccessTokenExpirationDate
//        {
//            get
//            {
//                return AppSettings.GetValueOrDefault<DateTime>("AccessTokenExpirationDate", DateTime.UtcNow);
//            }
//            set
//            {
//                AppSettings.AddOrUpdateValue<DateTime>("AccessTokenExpirationDate", value);
//            }
//        }
//    }
//}


