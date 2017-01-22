using System;
using System.Collections;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Simple_GridView_Search
{
    [Activity(Label = "Simple GridView Search", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private System.Collections.ArrayList techpreneurs;
        private GridView gv;
        private SearchView sv;
        private ArrayAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //INITIALIZE
            gv = FindViewById<GridView>(Resource.Id.gv);
            sv = FindViewById<SearchView>(Resource.Id.sv);

            //FILL DATA
            this.addData();

            //ADAPTER
            adapter=new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1,techpreneurs);
            gv.Adapter = adapter;

            //EVENT
            sv.QueryTextChange += sv_QueryTextChange;
            gv.ItemClick += gv_ItemClick;

        }

        void gv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           Toast.MakeText(this,adapter.GetItem(e.Position).ToString(),ToastLength.Short).Show();
        }

        void sv_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            //filter
            adapter.Filter.InvokeFilter(e.NewText);
        }

        private void addData()
        {
            techpreneurs=new ArrayList();
            techpreneurs.Add("Bill Gates");
            techpreneurs.Add("Steve Jobs");
            techpreneurs.Add("Ben Silbermann");
            techpreneurs.Add("Kevin Systrom");
            techpreneurs.Add("Brian Chesky");
            techpreneurs.Add("Mark Zuckerbag");
            techpreneurs.Add("Jack Dorsey");
            techpreneurs.Add("Elon Musk");
            techpreneurs.Add("John Doe");
            techpreneurs.Add("Peter Thiel");
            techpreneurs.Add("Larry Page");
            techpreneurs.Add("Sergey Brin");

        }


    }
}

