using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Symbol.EMDK.Xamarin;

namespace ProfileDataCaptureSample1
{
    [Activity(Label = "ProfileDataCaptureSample1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, EMDKManager.IEMDKListener
    {
        private EMDKManager emdkManager = null;
        private ProfileManager profileManager = null;

        private String profileName = "DataCaptureProfile-1";
        private String extraDataXML = "";

        private TextView tvStatus = null;
        private CheckBox cbCode128 = null;
        private CheckBox cbCode39 = null;
        private CheckBox cbEAN8 = null;
        private CheckBox cbEAN13 = null;
        private CheckBox cbUPCA = null;
        private CheckBox cbUPCE0 = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            tvStatus = FindViewById<TextView>(Resource.Id.textViewStatus);
            cbCode128 = FindViewById<CheckBox>(Resource.Id.checkBoxCode128);
            cbCode39 = FindViewById<CheckBox>(Resource.Id.checkBoxCode39);
            cbEAN8 = FindViewById<CheckBox>(Resource.Id.checkBoxEAN8);
            cbEAN13 = FindViewById<CheckBox>(Resource.Id.checkBoxEAN13);
            cbUPCA = FindViewById<CheckBox>(Resource.Id.checkBoxUPCA);
            cbUPCE0 = FindViewById<CheckBox>(Resource.Id.checkBoxUPCE0);

            AddButtonListener();

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

        #region IEMDKListener Members

        void EMDKManager.IEMDKListener.OnClosed()
        {
            tvStatus.Text = "Status: EMDK Open failed unexpectedly. Please close and restart the application ...";

            if (emdkManager != null)
            {
                emdkManager.Release();
                emdkManager = null;
            }
        }

        void EMDKManager.IEMDKListener.OnOpened(EMDKManager emdkManager)
        {
            tvStatus.Text = "Status: EMDK Opened successfully ...";

            this.emdkManager = emdkManager;

            try
            {
                profileManager = (ProfileManager)emdkManager.GetInstance(EMDKManager.FEATURE_TYPE.Profile);
                InitProfile();
            }
            catch (Exception e)
            {
                tvStatus.Text = "Status: Exception <" + e.Message + ">";
            }
        }

        #endregion

        void AddButtonListener()
        {
            Button btnSet = FindViewById<Button>(Resource.Id.buttonSet);

            btnSet.Click += delegate { ModifyProfileXML();};
        }

        void InitProfile()
        {
            
            if(profileManager != null)
            {
                EMDKResults results = profileManager.ProcessProfile(profileName, ProfileManager.PROFILE_FLAG.Set, new String[] {""});
                if(results.StatusCode != EMDKResults.STATUS_CODE.Success)
                {
                    tvStatus.Text = "Status: Profile initialization failed ...";
                }
                else
                {
                    tvStatus.Text = "Status: Profile initialization success ...";
                }
            }
            else
            {
                 tvStatus.Text = "Status: profileManager is null ...";
            }
        }

        void CreateExtraDataFromUI()
        {
            extraDataXML = "";

            extraDataXML += "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                            "<characteristic type=\"Profile\">" +
                            "<characteristic type=\"Barcode\" version=\"0.1\">" +
                            "<characteristic type=\"Decoders\">";

            if (cbCode128.Checked)
            {
                extraDataXML += "<parm name=\"decoder_code128\" value=\"true\"/>";
            }
            else
            {
                extraDataXML += "<parm name=\"decoder_code128\" value=\"false\"/>";
            }

            if (cbCode39.Checked)
            {
                extraDataXML += "<parm name=\"decoder_code39\" value=\"true\"/>";
            }
            else
            {
                extraDataXML += "<parm name=\"decoder_code39\" value=\"false\"/>";
            }

            if (cbEAN8.Checked)
            {
                extraDataXML += "<parm name=\"decoder_ean8\" value=\"true\"/>";
            }
            else
            {
                extraDataXML += "<parm name=\"decoder_ean8\" value=\"false\"/>";
            }

            if (cbEAN13.Checked)
            {
                extraDataXML += "<parm name=\"decoder_ean13\" value=\"true\"/>";
            }
            else
            {
                extraDataXML += "<parm name=\"decoder_ean13\" value=\"false\"/>";
            }

            if (cbUPCA.Checked)
            {
                extraDataXML += "<parm name=\"decoder_upca\" value=\"true\"/>";
            }
            else
            {
                extraDataXML += "<parm name=\"decoder_upca\" value=\"false\"/>";
            }

            if (cbUPCE0.Checked)
            {
                extraDataXML += "<parm name=\"decoder_upce0\" value=\"true\"/>";
            }
            else
            {
                extraDataXML += "<parm name=\"decoder_upce0\" value=\"false\"/>";
            }

            extraDataXML += "</characteristic>" +
                            "</characteristic>" +
                            "</characteristic>";
        }

        void ModifyProfileXML()
        {
            CreateExtraDataFromUI();
            
            String[] modifyData = new String[1];
            modifyData[0] = extraDataXML;

            EMDKResults results = profileManager.ProcessProfile(profileName, ProfileManager.PROFILE_FLAG.Set, modifyData);

            if (results.StatusCode != EMDKResults.STATUS_CODE.Success)
            {
                tvStatus.Text = "Profile modification failed ...";
            }
            else
            {
                tvStatus.Text = "Profile modification succeeded ...";
            }
        }
    }
}

