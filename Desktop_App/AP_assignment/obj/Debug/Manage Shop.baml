   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.4.0.9, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    AP_assignment   AP_assignment.Manage_Shop   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NMahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$	  App��5       � Title$ Manage Shop��5   	   $	��800��6   $
��1100��6*    � WindowStyle$ 
ToolWindow=�67    � WindowStartupLocation$ CenterScreen=�5   	      WindowTitleBrush
 ����   AccentColorBrush   	GlowBrush# �   5	   	      RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ btnHome��5      $
��Home��6&   65   �� 5      -   5         ��Name$ cmbUser��5      $��0q�6(   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Account��6R   ��6<   Z� .@�5      �� -   5        $��Logout��5      $
��Left=�60   $	��146��6K   ���	#FF48BBDC6x   5      5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   $	��770��6*   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ txtSearchQuery��5      $
��Left=�6*   $��26��6E   $��	38,31,0,0q�6Q    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��219��6�      ClearTextButton . 6�   1  +MahApps.Metro.IconPacks.PackIconFontAwesome  5   
   �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6(   $��
220,36,0,0q�66   $��14��6J   $��14��6V   �� 5   
   -   5        $ btnNew��5      $��+ New Product��6!   $��18��69   $��308,33,684,0q�6E   $	��Top=�6[   6s   �� 5   
   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgCoffee��5      $
��Left=�6%   $	��680��6@   $��	10,80,0,0q�6M   $	��Top=�6`   $
��1072��6x   |�.    CanUserAddRows .     MaxColumnWidth$	 100Q�6~     Columns 5       4  .System.Windows.Controls.DataGridTemplateColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Picture��6)      
IsReadOnly .    MinWidth$ 40Q�6L      CellTemplate 5"      �� 5#      .R�5$      �� $	��100��6?   $	��100��6K   ��6$   �� *	Picture+6K   5%      5'        5(      $ New Picture��6)    5)      �� 5*      .R�5+      �� -   5        ���	#FF0EBD5E.��5+   O   Add6T   5,      5.      51      54      55      