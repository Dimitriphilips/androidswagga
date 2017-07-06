using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System.Collections.Generic;
using System.Threading;
using RestSharp;
using System.Threading.Tasks;
using RSSwagga.Model;
using System.Net;
using System.Json;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace RSSwagga
{
    [Activity(Label = "App3", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Set view from the "main" layout resource
            SetContentView(Resource.Layout.HiScoresLayout);

            Button btnGetHS = FindViewById<Button>(Resource.Id.getHiScoreButton);

            btnGetHS.Click += delegate {
                getJSON();
            };
        }

        public void getJSON()
        {
            ListView lstSkill = FindViewById<ListView>(Resource.Id.listSkill);
            ListView lstRank = FindViewById<ListView>(Resource.Id.listRank);
            ListView lstLevel = FindViewById<ListView>(Resource.Id.listLevel);
            ListView lstXp = FindViewById<ListView>(Resource.Id.listXp);

            EditText editText = FindViewById<EditText>(Resource.Id.userText);
            string inputUser = editText.Text;


            List<HiScoreData> lstjson = new List<HiScoreData>();

            var adpSkill = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);
            var adpRank = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);
            var adpLevel = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);
            var adpXp = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);
            
            //Get JSON string from URL
            string jsonString = new WebClient().DownloadString("http://rs-swag.ga/api_v1/hiscores/" + inputUser);
            Console.WriteLine(jsonString);
            List<HiScoreData> listjson = JsonConvert.DeserializeObject <List<HiScoreData>>(jsonString);
            Console.WriteLine(listjson);

            foreach (HiScoreData hiscoredata in listjson)
            {
                adpSkill.Add(hiscoredata.skill);
                adpRank.Add(hiscoredata.rank);
                adpLevel.Add(hiscoredata.level);
                adpXp.Add(hiscoredata.xp);
                //Console.WriteLine(hiscoredata.skill);
                //Console.WriteLine(hiscoredata.rank);
                //Console.WriteLine(hiscoredata.level);
                //Console.WriteLine(hiscoredata.xp);
            }
            
            lstSkill.Adapter = adpSkill;
            lstRank.Adapter = adpRank;
            lstLevel.Adapter = adpLevel;
            lstXp.Adapter = adpXp;
        }   
    }
}


