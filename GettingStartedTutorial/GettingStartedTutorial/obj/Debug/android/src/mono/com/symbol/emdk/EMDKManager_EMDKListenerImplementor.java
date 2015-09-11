package mono.com.symbol.emdk;


public class EMDKManager_EMDKListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.symbol.emdk.EMDKManager.EMDKListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onClosed:()V:GetOnClosedHandler:Symbol.EMDK.Xamarin.EMDKManager/IEMDKListenerInvoker, Symbol.EMDK.Xamarin\n" +
			"n_onOpened:(Lcom/symbol/emdk/EMDKManager;)V:GetOnOpened_Lcom_symbol_emdk_EMDKManager_Handler:Symbol.EMDK.Xamarin.EMDKManager/IEMDKListenerInvoker, Symbol.EMDK.Xamarin\n" +
			"";
		mono.android.Runtime.register ("Symbol.EMDK.Xamarin.EMDKManager/IEMDKListenerImplementor, Symbol.EMDK.Xamarin, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null", EMDKManager_EMDKListenerImplementor.class, __md_methods);
	}


	public EMDKManager_EMDKListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EMDKManager_EMDKListenerImplementor.class)
			mono.android.TypeManager.Activate ("Symbol.EMDK.Xamarin.EMDKManager/IEMDKListenerImplementor, Symbol.EMDK.Xamarin, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onClosed ()
	{
		n_onClosed ();
	}

	private native void n_onClosed ();


	public void onOpened (com.symbol.emdk.EMDKManager p0)
	{
		n_onOpened (p0);
	}

	private native void n_onOpened (com.symbol.emdk.EMDKManager p0);

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
