package mono.com.symbol.emdk;


public class ProfileManager_DataListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.symbol.emdk.ProfileManager.DataListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onData:(Lcom/symbol/emdk/ProfileManager$ResultData;)V:GetOnData_Lcom_symbol_emdk_ProfileManager_ResultData_Handler:Symbol.EMDK.Xamarin.ProfileManager/IDataListenerInvoker, Symbol.EMDK.Xamarin\n" +
			"";
		mono.android.Runtime.register ("Symbol.EMDK.Xamarin.ProfileManager/IDataListenerImplementor, Symbol.EMDK.Xamarin, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null", ProfileManager_DataListenerImplementor.class, __md_methods);
	}


	public ProfileManager_DataListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ProfileManager_DataListenerImplementor.class)
			mono.android.TypeManager.Activate ("Symbol.EMDK.Xamarin.ProfileManager/IDataListenerImplementor, Symbol.EMDK.Xamarin, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onData (com.symbol.emdk.ProfileManager.ResultData p0)
	{
		n_onData (p0);
	}

	private native void n_onData (com.symbol.emdk.ProfileManager.ResultData p0);

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
