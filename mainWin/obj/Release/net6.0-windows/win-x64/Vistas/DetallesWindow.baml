   M S B A M L   `   `   `  ���� B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mainWin.VistasmainWin.Vistas  /clr-namespace:mainWin.VistasmainWin.Vistas  #    mainWin.Vistas.DetallesWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +ucclr-namespace:mainWin.Vistas     .localclr-namespace:mainWin.Vistas     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  -     N� Title$  
Pendientes��.��� -   .+�� -    �Name$ 	principal�� � ColumnDefinitions �� $
��Auto ��� $��* �.+�� -   $ control��$��0��   
gridExpand#��[  $��60��� -   $ expandedContent��$��1�����#E0E0E0.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0�����#108aa4$��60�� �� Padding$ 10q�._��  �� $��* ��� $��* ��� $��* �.+��� -    ��Name$ backBtn��$
��Left=�$��0��$��10q�  IconButtonStyle2#��[ $	����� $��1��$��10q�
������  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��Editar Orden��  DobleFontSize#���  �� -   ���	#331A1A1A$��5�� �� CornerRadius$ 20��$ 5q�  
Bordersize#���  ._��� $��Guardar��
�������$��Center=�$��Center=�  BaseFontSize#���  � $��2�� �� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��10q�$ 10��
�������$��3��$��0��$��0��._��  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* � �� $��* �.+���  �� Orientation$ 
Horizontal=�$��Center=�$��0��$��2��$��1��.+��� $��ID de Orden:��$��5q�#���  $
��Bold"��� -    ��Name$ textId��$��5q�#���  $��Light"����� *	IdOrden+�� $ 
Horizontal=�$��Center=�$��1��$��2��$��2��.+��� $��Fecha:��$
��Bold"�$��5q�#���  �� -	   $ 	textfecha��$��5q�#���  $��Light"����� *Fecha+�� -
   	 ��Name$	 borderPorPresupuestar�����#91d0dd$��4��$��3q�
������ $��1��#���  $ 20��$ 5q�._��� $��Por presupuestar��$��Center=�$��Center=�
�������$
��Bold"�#���  �� -   $	 borderEnProceso�����#fca47c$��5��$��1��$��3q�
������ $ 20��#���  $ 5q�._��� $��
En proceso��$��Center=�$��Center=�
�������$
��Bold"�#���  �� -   $	 borderPorEntregar�����#f7c292$��6��$��3q�
������ $��1��#���  $ 20��$ 5q�._��� $��Por entregar��$��Center=�$��Center=�
�������$
��Bold"�#���  �� $��10q�$��5��$��1��$ 10��$��2��
�������$��0��._��  �� $��* ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��Dispositivo:��$��0��$��0��#���  $
��Left=�$��10,0,0,0q�$
��Bold"�$��Center=��� -   
 ��Name$
 
textModelo��$��0��$��1��#���   �� TextWrapping$
 Wrap=�$��
ExtraLight"�$��0,0,0,1q�
�������$��10,0,0,0q�$��Center=����� *Modelo+�� $��Averia:��$��Center=�$��0��$��10,0,0,0q�#���  $
��Bold"�$��2���� -   $
 
textAveria��$��0��$��3��$��2��$��3��#���  $
 Wrap=�$��
ExtraLight"�$��0,0,0,1q�
�������$��10,0,0,0q����� *Averia+�� $��	Solucion:��$��Center=�$��0��$��10,0,0,0q�$
��Bold"�#���  $��5���� -   $
 textSolucion��$��0��$��3��$��2��$��6��#���  $
 Wrap=�$��
ExtraLight"�
������ $��10,0,0,0q����� *
Solucion+�� $��Observaciones:��$��Center=�$��0��$��10,0,0,0q�#���  $
��Bold"�$��8���� -   $
 textobs��$��0��$��3��$��2��$��9��#���  $
 Wrap=�$��
ExtraLight"�$��0,0,0,1q�
�������$��10,0,0,0q����� *Observaciones+�� $��10q�$��1��$��2��$ 10��
�������$��2��._�� $��30q� �� $��* ��� $��* � �� $��2* ��� $��10 ��� $��2* ��� $��10 ��� $��2* ��� $��10 ��� $��2* ��� $��10 �.+��� $��Cliente:��$��0��$��0��#���  $
��Left=�$
��Bold"�$��10,0,0,0q�$��Center=��� -   $
 textCliente��$��0��$��1��#���  $
 Wrap=�$��10,0,0,0q�$��
ExtraLight"�$��0,0,0,1q�
����������� *Cliente.Nombre+�� $��	Telefono:��$��2��$��0��#���  $
��Left=�$��10,0,0,0q�$
��Bold"�$��Center=��� -   $
 textTelefono��$��2��$��1��#���  $
 Wrap=�$��
ExtraLight"�$��10,0,0,0q�$��0,0,0,1q�
����������� *
Telefono+�� $��Dirección:��$��4��$��0��#���  $
��Left=�$��10,0,0,0q�$
��Bold"�$��Center=��� -   $
 	textDirec��$��4��$��1��$��2��#���  $
 Wrap=�$��10,0,0,0q�$��
ExtraLight"�$��0,0,0,1q�
����������� *Cliente.Direccion+�� $
��DNI:��$��6��$��0��#���  $
��Left=�$��10,0,0,0q�$
��Bold"�$��Center=��� -   $
 textdni��$��6��$��1��$��2��#���  $
 Wrap=�$��10,0,0,0q�$��
ExtraLight"�$��0,0,0,1q�
����������� *Cliente.Dni+�� $��10q�$��3��$��3��$ 10��
�������$��2��._��  �� $��* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��	Detalles:��$��0��#���  $
��Left=�$��10,0,0,0q�$
��Bold"�$��Center=��� $��Fecha Compromiso:��$��0��$��10,0,0,0q�#���  $��2��$
��Bold"�(  "System.Windows.Controls.DatePicker  $��1��#���  $��2��   SelectedDate �� *
Fecha_comp+�� $��
Prioridad:��$��0��$��4��#���  $��10,0,0,0q�$
��Bold"��� -    ��Name$ 	comboprio��  ComboBoxStyle1#���  #���  $��1��$��4��.@��� .��Alta�� .��Media�� .��Baja�� $��Asignado a:��$��0��$��6��#���  $��10,0,0,0q�$
��Bold"��� -   $ 	comboAsig��$��1��#���   �� DisplayMemberPath$ Nombre��#���   �� SelectedValuePath$ 
IdEmpleado��$��6��