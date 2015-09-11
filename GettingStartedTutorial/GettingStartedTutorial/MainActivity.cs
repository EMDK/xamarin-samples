using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Symbol.XamarinEMDK;
using Android.Util;

using System.Xml;
using System.IO;


namespace GettingStartedTutorial
{
    [Activity(Label = "GettingStartedTutorial", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, EMDKManager.IEMDKListener
    {
        private EMDKManager emdkManager = null;
        private ProfileManager profileManager = null;
        private String profileName = "ClockProfile";
        private TextView tvStatus = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            tvStatus = FindViewById<TextView>(Resource.Id.textViewStatus);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { ApplyProfile(); };

            EMDKResults results = EMDKManager.GetEMDKManager(Android.App.Application.Context, this);
            if (results.StatusCode != EMDKResults.STATUS_CODE.Success)
            {
                tvStatus.Text = "Status: EMDKManager object creation failed ...";
            }
            else
            {
                tvStatus.Text = "Status: EMDKManager object creation succeeded ...";
            }
        }

        void EMDKManager.IEMDKListener.OnOpened(EMDKManager emdkManager)
        {
            tvStatus.Text = "Status: EMDK Opened successfully ...";

            this.emdkManager = emdkManager;

            try
            {
                profileManager = (ProfileManager)emdkManager.GetInstance(EMDKManager.FEATURE_TYPE.Profile);
            }
            catch (Exception e)
            {
                tvStatus.Text = "Status: Exception <" + e.Message + ">";
            }
        }

        void EMDKManager.IEMDKListener.OnClosed()
        {
            tvStatus.Text = "Status: EMDK Open failed unexpectedly. Please close and restart the application ...";

            if (emdkManager != null)
            {
                emdkManager.Release();
                emdkManager = null;
            }
        }

        void ApplyProfile()
        {
            if (profileManager != null)
            {
                EMDKResults results = profileManager.ProcessProfile(profileName, ProfileManager.PROFILE_FLAG.Set, new String[] { "" });
                if (results.StatusCode == EMDKResults.STATUS_CODE.Success)
                {
                    tvStatus.Text = "Status: Profile applied successfully ..."; 
                }
                else if (results.StatusCode == EMDKResults.STATUS_CODE.CheckXml)
                {
                    //Inspect the XML response to see if there are any errors, if not report success

                    using (XmlReader reader = XmlReader.Create(new StringReader(results.StatusString)))
                    {
                        String checkXmlStatus = "Status:\n\n";
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    switch (reader.Name)
                                    {
                                        case "parm-error":
                                            checkXmlStatus +=  "Parm Error:\n";
                                            checkXmlStatus += reader.GetAttribute("name") + " - ";
                                            checkXmlStatus += reader.GetAttribute("desc") + "\n\n";
                                            break;
                                        case "characteristic-error":
                                            checkXmlStatus += "characteristic Error:\n";
                                            checkXmlStatus += reader.GetAttribute("type") + " - ";
                                            checkXmlStatus += reader.GetAttribute("desc") + "\n\n";
                                            break;
                                    }
                                    break;
                            }
                        }

                        if (checkXmlStatus == "Status:\n\n")
                        {
                            tvStatus.Text = "Status: Profile applied successfully ...";
                        }
                        else
                        {
                            tvStatus.Text = checkXmlStatus;
                        }
                        
                    }
                }
                else
                {
                    tvStatus.Text = "Status: Profile initialization failed ... " + results.StatusCode;
                }
            }
            else
            {
                tvStatus.Text = "Status: profileManager is null ...";
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (profileManager != null)
            {
                profileManager = null;
            }

            if (emdkManager != null)
            {
                emdkManager.Release();
                emdkManager = null;
            }
        }






    }
}

