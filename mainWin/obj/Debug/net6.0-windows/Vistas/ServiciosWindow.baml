   M S B A M L   `   `   `  ����B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mainWin.VistasmainWin.Vistas  5      /clr-namespace:mainWin.VistasmainWin.Vistas  5      $    mainWin.Vistas.ServiciosWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:mainWin.Vistas     5      +ucclr-namespace:mainWin.Vistas     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5        N� Title$  ServiciosWindow��5      .��5      � -   5         � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ control��5      $��0��5         
gridExpand#��[  5      $��60��5      5      � 5   
   -   5        $ expandedContent��5      $��1��5      ���#E0E0E0.+�5       �  � RowDefinitions 5!      �� 5#      $
��Auto �6$   �� 5$      $
��Auto �6$   �� 5&      $��* �6$   .+�5*      �� $��0��6   $��60��5+      ���#d8a874 �� Padding$ 10q�5-      ._�5.      �  5/      �� 51      $��* �6/   �� 52      $��* �6/   �� 53      $��* �6/   .+�57      �� -   5         ��Name$ backBtn��58   !   $
��Left=�57   !   $��0��59   !   $��10q�5:   !     IconButtonStyle2#��[ 5;   !   $	����5<   !   5=   !   5>      5@      �� 5C      $��2��6   $��10q�5D       �� CornerRadius$ 10��5E      
�������._�5H      &   System.Windows.Controls.DataGrid  $��10q�6    
�������   AutoGenerateColumns$
 True��5J         TarjetaStyle   RowStyle# [ 5L         MinimalDataGridHeaderStyle	   ColumnHeaderStyle#	 [ 5M         MinimalDataGridStyle#��[ 5N       
   SelectionMode$
 Extended=�5O          SelectionUnit$ FullRow=�5P       ��5K       ��    	CellStyle 5R      �� 5S       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6$   .�5T   "   ��  �� Property � �� �� Value$ 10q�5U   )   �� 5V   "    � ��$ 60��5W   )    �� Triggers 5Y   "   P� 5Z   &    P� Property �@ 
IsSelected P� Value$
 True��5[   .   . �5\   *   ��  � ��
 �����5]   1   �� 5^   *    � ��
 ���� 5_   1   �� 5`   *    � ��
 �   �5a   1   5c   '   5e      5h      5j      5l      5n      5p      5q      