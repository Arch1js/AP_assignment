   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.4.0.9, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    AP_assignment!   AP_assignment.AddNewProduct   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NMahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$	  App��5       � Title$ New Product��5   	   $	��700��6   $
��1000��6*    � WindowStyle$ 
ToolWindow=�67    � WindowStartupLocation$ CenterScreen=�5   	      WindowTitleBrush
 �"�"�   AccentColorBrush   	GlowBrush# �   5	   	      RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ btnHome��5      $
��Home��6&   65   �� 5      -   5         ��Name$ cmbUser��5      $��0q�6(   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Account��6R   ��6<   Z� .@�5      �� -   5        $��Logout��5      $
��Left=�60   $	��146��6K   ���	#FF48BBDC6z   5      5      .��5      � .+�5   
   �� -   5        
 ��Name$
 txtName��5      $
��Left=�6$   $��30��6?   $��
166,56,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��310��6�   �� 5   
   -   5        $
 txtStrength��5      $
��Left=�6'   $��30��6B   $��166,136,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��310��6�   �� 5   
   -   5        $
 txtGrind��5      $
��Left=�6$   $��30��6?   $��166,212,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��310��6�   �� 5   
   -   5        $
 	txtOrigin��5      $
��Left=�6%   $��28��6@   $��166,280,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��310��6�   �� 5   
   -	   5        $
 txtAvailable��5      $
��Left=�6(   $��30��6C   $��166,352,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��310��6�   �� 5   
   -
   5        $
 
txtTrigger��5      $
��Left=�6&   $��30��6A   $��166,426,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��310��6�   �� 5   
   -   5        $
 txtDescription��5      $
��Left=�6*   $��98��6E   $��
522,72,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��432��6�    �� AcceptsReturn .  �� 
AcceptsTab .  �� AutoWordSelection .  �� 	MaxLength$	 200��6�   6�   �� 5   
   -   5        $
 txtComments��5      $
��Left=�6'   $��98��6B   $��522,216,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��432��6�    .  .  . $	 300��6�   6�   �� 5   
   -   5         ��Name$ 
lblStaffID��5      $��Name:��6$   $
��Left=�64   $��30��6O   $��
106,56,0,0q�6[   $	��Top=�6o   $	��102��6�   �� 5   
   -   5        $ lblStrnegth��5      $��Coffee Strength:��6%   $
��Left=�6@   $��30��6[   $��
58,136,0,0q�6g   $	��Top=�6{   $	��150��6�   �� 5   
   -   5        $ 	lblOrigin��5      $��Origin:��6#   $
��Left=�65   $��28��6P   $��110,280,0,0q�6\   $	��Top=�6q   $��98��6�   �� 5   
   -   5        $ lblAvailable��5      $��Available Quantity:��6&   $
��Left=�6D   $��30��6_   $��
46,352,0,0q�6k   $	��Top=�6   $	��162��6�   �� 5   
   -   5        $ lblDescription��5      $��Description:��6(   $
��Left=�6?   $��28��6Z   $��
522,44,0,0q�6f   $	��Top=�6z   $	��194��6�   �� 5    
   -   5        $ btnSave��5       $
��Save��6"   $
��Left=�61   $��46��6L   $��310,551,0,0q�6X   $	��Top=�6m   $	��157��6�   ���	#FF15A9EE$��22(�6�   �� 5!   
   -   5        $ btnClear��5!      $��Clear��6#   $
��Left=�63   $��107,551,0,0q�6N   $	��Top=�6c   $	��154��6{   ���	#FFE0362E$��46��6�   $��22(�6�   6�   �� 5#   
   -   5        $ lblGrind��5#      $��Coffee Grind:��6"   $
��Left=�6:   $��30��6U   $��
74,212,0,0q�6a   $	��Top=�6u   $	��142��6�   1  +MahApps.Metro.IconPacks.PackIconFontAwesome  5$   
   �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null]]   Kind$ FloppyOutline=�6(   $��324,564,0,0q�6=   $��20��6R   $��37��6^     5%   
   $ Times=�6(   $��120,569,0,0q�65   $��15��6J   $��26��6V   �� 5&   
   -   5        $ 
lblPicture��5&      $��Add product picture:��6$   $
��Left=�6C   $��522,344,0,0q�6^   $	��Top=�6s   �� 5'   
   -   5        $ lblTextCount��5'      $�� ��6&   $
��Left=�61   $��24��6L   $��690,192,0,0q�6X   $	��Top=�6m   $	��112��6�   �� 5(   
   -   5        $ lblTextCount2��5(      $�� ��6'   $
��Left=�62   $��24��6M   $��
604,44,0,0q�6Y   $	��Top=�6m   $	��112��6�   �� 5)   
   -   5        $ 
lblTrigger��5)      $��Trigger Quantity:��6$   $
��Left=�6@   $��30��6[   $��
58,426,0,0q�6g   $	��Top=�6{   $	��150��6�   �� 5*   
   -   5        $ lblComments��5*      $"��Comments (For internal use):��6%   $
��Left=�6L   $��24��6g   $��522,192,0,0q�6s   $	��Top=�6�   $	��168��6�   �� 5+   
   -   5        $ 	btnBrowse��5+      $��Upload��6$   $
��Left=�65   $��656,345,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5,   
   -   5         ��Name$ imageUpload��5,      $
��Left=�6%   $	��202��6@   $��522,395,0,0q�6M   $	��Top=�6b   $	��316��6z   �� 5-   
   -   5        $
 txtPrice��5-      $
��Left=�6$   $��30��6?   $��166,490,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��310��6�   �� 5.   
   -   5        $ Price��5.      $��Price:��6   $
��Left=�60   $��30��6K   $��
58,490,0,0q�6W   $	��Top=�6k   $	��150��6�   5/      50      