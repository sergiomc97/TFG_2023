   M S B A M L   `   `   `  ���� B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mainWin.VistasmainWin.Vistas  /clr-namespace:mainWin.VistasmainWin.Vistas  %    mainWin.Vistas.PendientesWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  %ucclr-namespace:mainWin.Vistas  (localclr-namespace:mainWin.Vistas    N� Title$  
Pendientes�� � 	Resources ,   &mainWin.Vistas.BooleanToColorConverter   BooleanToColorConverter��%   &	          .��� -   .+�� -    �Name$ MyPopup�� � AllowsTransparency$
 True��$��Scroll=�$��False��$��Center=�.����  �� Padding$	 100q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 1Q�   Color$ Black��   Opacity$ 1Q�	   
BlurRadius$	 50Q�._��� 
�������
 �� CornerRadius$
 10��$	��500��$	��500��$��1��._��  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$��10q�$
��Left=�.+��� $��Nuevo Registro:��$��20(��� $��0��$��10q�$ 
Horizontal=�$��Right=�.+��� -     IconButtonStyle3#��[ $	����$��5q��� $��1��$��10q�.+��� $��Nombre:���� -    ��Name$ NombreTextBox��  TextBoxStyle#��[ �� $��
Teléfono:��$��0,10,0,0q��� -   $ TelefonoTextBox��#��[ �� $��	Anticipo:��$��0,10,0,0q��� -   $ AnticipoTextBox��#��[ �� $��Precio:��$��0,10,0,0q��� -   $ PrecioTextBox��#��[ �� $��Pedido:��$��0,10,0,0q��� -   $ PedidoTextBox��#��[ �� $��2��$ 
Horizontal=�$��Center=�.+��� -	   $��Guardar��  RoundButtonStyle2#��[ $��10q��� -
   $��Cancelar��#��[ ���#fe6701$��10q�� -    �Name$ 	principal�� � ColumnDefinitions �� $
��Auto ��� $��* �.+�� -   $ control��$��0��  
gridExpand#��[ $��60��� -   $ expandedContent��$��1�����#E0E0E0.+��  �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0�����#108aa4$ 10q�._��  �� $��* ��� $��* ��� $��* �.+��� -    ��Name$ backBtn��$
��Left=�$��0��$��10q�  IconButtonStyle2#��[ $	����� $��1��.+��� ���	#331A1A1A$
 20��$ 5q�._��  �� $
��Auto ��� $��* �.+��� $��30��$��30�����	#4CFFFFFF$
 15��._��� $��Center=�$��Center=�$	����$��Segoe MDL2 Assets)��� -   $
 busq��$��1��  textBoxStyle#��[ .���� ���	#331A1A1A$	��300��$	��-10q�$��2��$ 5q�._��  �� $��* ��� $��* ��� $��* �.+��� -   $��0��  HoverBorderStyle#��[ ._��� -   $ BtnNuevo��#��[ $	������ -   $��1��#��[ ._��� -   $ BtnRefrescar��#��[ $	������ $��2��#��[ ._��� #��[ $	������ $��2��$��10q�$
 10��
�������._��  �� $
��Auto ��� $��* �.+���   CabeceraStyle#��[ ._�� $��0��$��50�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -   $	 fch��$��Center=�$��0�� 	 IconButtonStyle#��[	 $��Fecha���� -   $	 nom��$��Center=�$��1��#��[	 $��Cliente���� -   $	 Ped��$��Center=�$��2��#��[	 $��Pedido���� -   $	 tlf��$��3��#��[	 $��Telefono���� -   $	 Ant��$��4��#��[	 $��Anticipo���� -   $	 pre��$��5��#��[	 $��Precio���� -   $	 est��$��6��#��[	 $��Estado���� $��1��$
��Auto=�$
��Auto=�.���  �� $
��Auto ��� $��* �.+��� $��1������ ���� .R��� $��1q� 
 TarjetaStyle2#��[
 ._�� $��50�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��Center=�$��0������ *Fecha+�� $��Center=�$��1������ *Nombre+�� $��Center=�$��2������ *Pedido+�� $��Center=�$��3������ *
Telefono+�� $��Center=�$��4������ *
Anticipo+�� $��Center=�$��5������ *Precio+��  ��Name$ 
BorderPend��-   $��20��$��6������ *
Completado+ �� 	Converter# [  