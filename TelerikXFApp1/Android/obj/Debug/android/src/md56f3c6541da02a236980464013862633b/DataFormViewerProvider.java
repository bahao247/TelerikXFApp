package md56f3c6541da02a236980464013862633b;


public class DataFormViewerProvider
	extends md56f3c6541da02a236980464013862633b.DataFormViewProviderBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.InputRenderer.Android.DataForm.DataFormViewerProvider, Telerik.XamarinForms.InputRenderer.Android, Version=2016.3.1202.233, Culture=neutral, PublicKeyToken=null", DataFormViewerProvider.class, __md_methods);
	}


	public DataFormViewerProvider () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DataFormViewerProvider.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.InputRenderer.Android.DataForm.DataFormViewerProvider, Telerik.XamarinForms.InputRenderer.Android, Version=2016.3.1202.233, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public DataFormViewerProvider (md5aca75a00e217168bbb349a90d45f39c5.DataFormRenderer p0, com.telerik.widget.dataform.visualization.RadDataForm p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == DataFormViewerProvider.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.InputRenderer.Android.DataForm.DataFormViewerProvider, Telerik.XamarinForms.InputRenderer.Android, Version=2016.3.1202.233, Culture=neutral, PublicKeyToken=null", "Telerik.XamarinForms.InputRenderer.Android.DataFormRenderer, Telerik.XamarinForms.InputRenderer.Android, Version=2016.3.1202.233, Culture=neutral, PublicKeyToken=null:Com.Telerik.Widget.Dataform.Visualization.RadDataForm, Telerik.Xamarin.Android.Input, Version=2016.3.1202.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
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
