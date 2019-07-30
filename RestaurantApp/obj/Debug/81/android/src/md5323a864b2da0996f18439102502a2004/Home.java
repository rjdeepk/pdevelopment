package md5323a864b2da0996f18439102502a2004;


public class Home
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("RestaurantApp.Home, RestaurantApp", Home.class, __md_methods);
	}


	public Home ()
	{
		super ();
		if (getClass () == Home.class)
			mono.android.TypeManager.Activate ("RestaurantApp.Home, RestaurantApp", "", this, new java.lang.Object[] {  });
	}

	public Home (java.lang.String p0, java.lang.String p1)
	{
		super ();
		if (getClass () == Home.class)
			mono.android.TypeManager.Activate ("RestaurantApp.Home, RestaurantApp", "System.String, mscorlib:System.String, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}

	public Home (java.lang.String p0, android.app.Fragment p1)
	{
		super ();
		if (getClass () == Home.class)
			mono.android.TypeManager.Activate ("RestaurantApp.Home, RestaurantApp", "System.String, mscorlib:Android.App.Fragment, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}

	public Home (java.lang.String p0, android.app.Fragment[] p1)
	{
		super ();
		if (getClass () == Home.class)
			mono.android.TypeManager.Activate ("RestaurantApp.Home, RestaurantApp", "System.String, mscorlib:Android.App.Fragment[], Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

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
