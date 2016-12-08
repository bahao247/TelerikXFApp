package md50c7fa6cbe21f251e9332f1d0d6f0b410;


public class ChartPalette
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ChartBindings.ChartPalette, Telerik.Xamarin.Android.Chart, Version=2016.3.1202.0, Culture=neutral, PublicKeyToken=null", ChartPalette.class, __md_methods);
	}


	public ChartPalette () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ChartPalette.class)
			mono.android.TypeManager.Activate ("ChartBindings.ChartPalette, Telerik.Xamarin.Android.Chart, Version=2016.3.1202.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
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
