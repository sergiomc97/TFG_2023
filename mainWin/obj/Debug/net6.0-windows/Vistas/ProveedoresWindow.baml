   M S B A M L   `   `   `  ����B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mainWin.VistasmainWin.Vistas  5      /clr-namespace:mainWin.VistasmainWin.Vistas  5      &     mainWin.Vistas.ProveedoresWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:mainWin.Vistas     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      %ucclr-namespace:mainWin.Vistas  5        N� Title$  ProveedoresWindow��5      .��5      � -   5         � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ control��5      $��0��5         
gridExpand#��[  5      $��60��5      5      � 5   
   -   5        $ expandedContent��5      $��1��5      ���#E0E0E0.+�5      �  � RowDefinitions 5       �� 5"      $
��Auto �6$   �� 5#      $
��Auto �6$   �� 5%      $��* �6$   .+�5)      �� $��0��6   $��60��5*      ���#a4c8cf �� Padding$ 10q�5,      ._�5-      �  5.      �� 50      $��* �6/   �� 51      $��* �6/   �� 52      $��* �6/   .+�56      �� -   5         ��Name$ backBtn��57   !   $
��Left=�56   !   $��0��58   !   $��10q�59   !     IconButtonStyle2#��[ 5:   !   $	����5;   !   5<   !   5=      5?      �� 5B      $��2��6   $��10q�5C       �� CornerRadius$ 10��5D      
�������._�5G      &   System.Windows.Controls.DataGrid  $��10q�6    
�������   AutoGenerateColumns$
 True��5I         TarjetaStyle   RowStyle# [ 5K         MinimalDataGridHeaderStyle	   ColumnHeaderStyle#	 [ 5L         MinimalDataGridStyle#��[ 5M       
   SelectionMode$
 Extended=�5N          SelectionUnit$ FullRow=�5O       ��5J       ��    	CellStyle 5Q      �� 5R       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6$   .�5S   "   ��  �� Property � �� �� Value$ 10q�5T   )   �� 5U   "    � ��$ 60��5V   )    �� Triggers 5X   "   P� 5Y   &    P� Property �@ 
IsSelected P� Value$
 True��5Z   .   . �5[   *   ��  � ��
 �����5\   1   �� 5]   *    � ��
 ���� 5^   1   �� 5_   *    � ��
 �   �5`   1   5b   '   5d      5g      5i      5k      5m      5o      5p      