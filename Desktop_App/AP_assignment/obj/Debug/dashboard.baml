   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.4.0.9, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    AP_assignment   AP_assignment.dashboard   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NMahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$	  App��5       � Title$ 	Dashboard��5   	   $	��800��6   $
��1300��6(    � WindowStartupLocation$ CenterScreen=�5   	      AccentColorBrush   	GlowBrush# �   5   	      WindowTitleBrush
 �"�"� � WindowStyle$ 
ToolWindow=�5	   (      RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ btnHome��5      $
��Home��6&   65   �� 5      -   5         ��Name$ cmbUser��5      $��0q�6(   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Account��6R   ��6<   Z� .@�5      �� -   5        $��Logout��5      $
��Left=�60   $	��146��6K   ���	#FF48BBDC6x   5      5      .��5      � -   5        .+�5   
   (  "System.Windows.Controls.WebBrowser  -   5        
  Name$
 reportBrowser��5      $
��Left=�6,   $	��711��6G   $��	10,49,0,0q�6T   $	��Top=�6g   $
��1272��6    � OverridesDefaultStyle . 6�   �� 5   
   -   5        $ btnBack��5      $
��Back��6"   $
��Left=�61   $��13��6L   $��	44,19,0,0q�6X   $	��Top=�6k   $��72��6�   ���	#FF0F9FBF6�   1  +MahApps.Metro.IconPacks.PackIconFontAwesome  5   
   �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null]]   Kind$ 	CaretLeft=�6(   $��	46,26,0,0q�69   $��12��6L   $��12��6X   6e   5      5      