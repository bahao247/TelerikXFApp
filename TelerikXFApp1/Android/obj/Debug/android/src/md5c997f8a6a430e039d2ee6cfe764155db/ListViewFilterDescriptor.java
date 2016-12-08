package md5c997f8a6a430e039d2ee6cfe764155db;


public class ListViewFilterDescriptor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.telerik.android.common.Function
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_apply:(Ljava/lang/Object;)Ljava/lang/Object;:GetApply_Ljava_lang_Object_Handler:Com.Telerik.Android.Common.IFunctionInvoker, Telerik.Xamarin.Android.Common\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.DataControlsRenderer.Android.ListView.ListViewFilterDescriptor, Telerik.XamarinForms.DataControlsRenderer.Android, Version=2016.3.1202.233, Culture=neutral, PublicKeyToken=null", ListViewFilterDescriptor.class, __md_methods);
	}


	public ListViewFilterDescriptor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ListViewFilterDescriptor.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.DataControlsRenderer.Android.ListView.ListViewFilterDescriptor, Telerik.XamarinForms.DataControlsRenderer.Android, Version=2016.3.1202.233, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object apply (java.lang.Object p0)
	{
		return n_apply (p0);
	}

	private native java.lang.Object n_apply (java.lang.Object p0);

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
