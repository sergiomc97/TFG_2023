   M S B A M L   `   `   `  ���� B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mainWin.VistasmainWin.Vistas  #    mainWin.Vistas.ClinetesWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +ucclr-namespace:mainWin.Vistas     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/    N� Title$  ClinetesWindow��.��� -    � ColumnDefinitions �� $
��Auto ��� $��* �.+�� -    �Name$ control��$��0��   
gridExpand#��[  $��60��� -   $ expandedContent��$��1�����#E0E0E0.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��60�����#108aa4 �� Padding$ 10q�._��  �� $��* ��� $��* ��� $��* �.+��� -    ��Name$ backBtn��$
��Left=�$��0��$��10q�  IconButtonStyle2#��[ $	������ $��2��$��10q� �� CornerRadius$ 10��
�������._�&   System.Windows.Controls.DataGrid  $��10q�
�������   AutoGenerateColumns$ False��  TarjetaStyle   RowStyle# [   MinimalDataGridHeaderStyle	   ColumnHeaderStyle#	 [   MinimalDataGridStyle#��[ 
   SelectionMode$
 Extended=�   SelectionUnit$ FullRow=�����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150    Header �� $��
Id cliente��  MidFontSize#���  $��Center=�$��Center=�   CellTemplate �� .R��� $��15(�$��Center=�$��Center=����� *	IdCliente+  $	 350  �� $��Nombre��#���  $��Center=�$��Center=� �� .R��� $��15(�$��Center=�$
��Left=����� *Nombre+  $	 150  �� $��Telefono��#���  $��Center=�$��Center=� �� .R��� $��15(�$��Center=�$��Center=����� *
Telefono+  $	 250  �� $��Ordenes��#���  $��Center=�$��Center=� �� .R��� $��Center=����� *	Ordenes+  $	 250  �� $��Citas��#���  $��Center=�$��Center=� �� .R��� $��Center=����� *Cita+   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value$ 10q���  � ��$ 60�� �� Triggers P�  P� Property �@ 
IsSelected P� Value$
 True��. ���  � ��
 �������  � ��
 ���� ��  � ��
 �   �