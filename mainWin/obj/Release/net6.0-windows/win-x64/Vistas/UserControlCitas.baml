   M S B A M L   `   `   `  ���� B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mainWin.VistasmainWin.Vistas  %    mainWin.Vistas.UserControlCitas   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:mainWin.Vistas     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  .���   � ColumnDefinitions  �� $��* � � RowDefinitions �� $��* �.+��� 
�������
������ $��0q� �� CornerRadius$ 10�� �� Padding$ 10q�._�&   System.Windows.Controls.DataGrid  -     Name$ 	gridCitas��   AutoGenerateColumns$ False��
�������$
��Auto��$
��Auto��   TarjetaStyle   RowStyle# [    MinimalDataGridHeaderStyle   ColumnHeaderStyle# [   MinimalDataGridStyle#��[ $��Segoe ui)�   SelectionMode$ Extended=�	   SelectionUnit$	 FullRow=����� 
   Columns
 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100    Header �� $��Fecha��  BaseFontSize#���  ���	#ff2f4f4f$��Center=�$��Center=�   CellTemplate �� .R��� $��Center=�$��Center=����� *Fecha+ �� StringFormat$ {0:dd/MM/yyyy}��  $	 100  �� $
��Hora�����	#ff2f4f4f#���  $��Center=�$��Center=� �� .R��� $��Center=�$��Center=����� *Hora+  $	 350  �� $��Cliente�����	#ff2f4f4f#���  $��Center=�$��Center=� �� .R��� $��Center=�$��Center=����� *Cliente.Nombre+  $	 200  �� $��Descripcion�����	#ff2f4f4f#���  $��Center=�$��Center=� �� .R��� $��Center=�$��Center=����� *Desc+  $  ��$	 100  �� .R��� ._���  ��Name$ delete��-   
������ $��40��$��25��$��Center=�
������ .��"  FontAwesome.WPF.ImageAwesome     Icon$ trash=�   
Foreground
 �����   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"   �� Triggers P�  P� Property �@ 
IsSelected P� Value$
 True��. ���  �� Property � �� �� Value
 �������  � ��
 ���� ��  � ��
 �   �