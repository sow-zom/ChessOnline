using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace ChessOnline
{
    class MoveC
    {
        public string cnt { get; set; }
        public string ID { get; set; }
        public string Move { get; set; }
    }

    public static class meth
    {
        //public static async void ConectTest(IFirebaseClient client)
        //{
        //    var data = new MoveC
        //    {
        //        cnt = "connected"
        //    };
        //    try { SetResponse response = await client.SetTaskAsync("TestConect/" + data.cnt, data); Data result = response.ResultAs<SetMove>(); }
        //    catch (NullReferenceException) { MessageBox.Show("Ошибка соединения.\nПроверьте правильность данных в настройках\n и подключение к интернету."); Environment.Exit(0); }
        //    try { FirebaseResponse response = await client.GetTaskAsync("TestConect"); Class1 result = response.ResultAs<Class1>(); }
        //    catch (NullReferenceException) { MessageBox.Show("Ошибка соединения.\nПроверьте правильность данных в настройках\n и подключение к интернету."); Environment.Exit(0); }
        //    FirebaseResponse response2 = await client.DeleteTaskAsync("TestConect");
        //}
    }
}