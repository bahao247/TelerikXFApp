package md5f8aa3123340f29bc4286faf4a14897db;


public class CustomCartesianGridLineAnnotation
	extends com.telerik.widget.chart.visualization.annotations.cartesian.CartesianGridLineAnnotation
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_drawCore:(Landroid/graphics/Canvas;)V:GetDrawCore_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.ChartRenderer.Android.CustomCartesianGridLineAnnotation, Telerik.XamarinForms.ChartRenderer.Android, Version=2016.3.1202.233, Culture=neutral, PublicKeyToken=null", CustomCartesianGridLineAnnotation.class, __md_methods);
	}


	public CustomCartesianGridLineAnnotation (com.telerik.widget.chart.visualization.common.CartesianAxis p0, java.lang.Object p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == CustomCartesianGridLineAnnotation.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.CustomCartesianGridLineAnnotation, Telerik.XamarinForms.ChartRenderer.Android, Version=2016.3.1202.233, Culture=neutral, PublicKeyToken=null", "Com.Telerik.Widget.Chart.Visualization.Common.CartesianAxis, Telerik.Xamarin.Android.Chart, Version=2016.3.1202.0, Culture=neutral, PublicKeyToken=null:Java.Lang.Object, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public void drawCore (android.graphics.Canvas p0)
	{
		n_drawCore (p0);
	}

	private native void n_drawCore (android.graphics.Canvas p0);

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
