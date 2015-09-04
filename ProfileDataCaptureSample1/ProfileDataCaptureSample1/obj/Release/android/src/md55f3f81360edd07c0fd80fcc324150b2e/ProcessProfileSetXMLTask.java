package md55f3f81360edd07c0fd80fcc324150b2e;


public class ProcessProfileSetXMLTask
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("symbol.xamarinemdk.profiledatacapturesample1.ProcessProfileSetXMLTask, ProfileDataCaptureSample1, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null", ProcessProfileSetXMLTask.class, __md_methods);
	}


	public ProcessProfileSetXMLTask () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ProcessProfileSetXMLTask.class)
			mono.android.TypeManager.Activate ("symbol.xamarinemdk.profiledatacapturesample1.ProcessProfileSetXMLTask, ProfileDataCaptureSample1, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
