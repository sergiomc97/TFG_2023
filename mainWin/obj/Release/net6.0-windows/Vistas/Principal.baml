   M S B A M L   `   `   `  ���� B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mainWin.VistasmainWin.Vistas  /clr-namespace:mainWin.VistasmainWin.Vistas      mainWin.Principal   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +ucclr-namespace:mainWin.Vistas     .localclr-namespace:mainWin.Vistas     C	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/    N� Title$  
MainWindow��.��� -   .+�� -    �Name$ 	principal�� � ColumnDefinitions �� $
��Auto ��� $��* �.+�� -   $ control��$��0�����#c7e3eb   
gridExpand#��[  $��60��� -   $ contenedorPrincipal�����#c0e3e9$��1�� �� $��* � � RowDefinitions �� $
��auto ��� $��* ��� $��* �.+��� ���	#331A1A1A
������ ._��  �� $��* ��� $��* ��� $��* �.+�� $��2�� �� $
��auto ��� $��* ��� $
��auto ��� $��* � �� $��* ��� $��* ��� $��* �.+�"  FontAwesome.WPF.ImageAwesome  -     Name$
 noti��   Icon$ BellOutline=�$��0��$��Center=�   
Foreground
 �����$��60��$��23���� $��Center=�$��0�����#fe6701$��20(�$��20,0,0,0q����� *DebugInfoModel.cont+�� $��1��$��0��$��Center=�
�������  BaseFontSize#���  $��30,0,0,0q����� *DebugInfoModel.Msg+  $ UserOutline=�$��2��
 �����$��60��$��20���� -    ��Name$ username��$��3��$��Center=�
�������#���  $��30,0,0,0q�  -   $ PowerOff=�$��3��
 �����$��60��$��20��� $��1��$��1�� �� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* �.+�� $��10q�$��0��$��0��.+��� -    ��Name$ 
porpresupu��  RoundButtonStyle#��[ .���� 	 �� Orientation$	 
Horizontal=�.+�  -	   $
 ico0��$ HandshakeOutline=�  DobleFontSize#���   �	#ff2f4f4f$��10q�$��25���� -
   $ 
numPresupu�����	#ff2f4f4f#���  $��10q��� $��Por presupuestar�����	#ff2f4f4f#���  $��10q�� $��10q�$��0��$��1��.+��� -   $ 	enproceso��#��[ .���� $	 
Horizontal=�.+�  -   $
 ico1��$ ClockOutline=�#���   �	#ff2f4f4f$��10q�$��25���� -   $ 
numProceso�����	#ff2f4f4f#���  $��10q��� $��
En proceso�����	#ff2f4f4f#���  $��10q�� $��10q�$��0��$��2��.+��� -   $ porentregar��#��[ .���� $	 
Horizontal=�.+�  -   $
 ico2��$ Dropbox=�#���  $��10q� �	#ff2f4f4f$��25���� -   $ numEntregar�����	#ff2f4f4f#���  $��10q��� $��Por entregar�����	#ff2f4f4f#���  $��10q�� $��10q�$��2��$��1��$��0��.+��� -   #��[ .���  �� $��* ��� $��* �.+��� $��
Pendientes��$��0�����	#ff2f4f4f#���  �� -   $ NumPend��$��0�����	#ff2f4f4f$��2��$��Center=�$	��Top=�  DobleDobleFontSize#���  � $��10q�$��1��$��2��$��2��$��1��.+��� 
�������
������ $��0q�
 �� CornerRadius$
 0�� �� Padding$ 10q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 1Q�   Opacity$	 0.4Q�._��  �� $
��auto ��� $��* �.+��� $��Citas con clientes:��$��0�����	#ff2f4f4f$
��Left=�#���  �� -   ._�  -   $ newCita��$ PlusSquareOutline=� �	#ff2f4f4f#���  $��0��$��Right=�$��25��� -   $ contenedorCitas��$��1��� $��10q�$��2��.+��� 
�������
������ $��0q�$
 0��$ 10q�   $ 10Q�$ 1Q�$	 0.4Q�._��  �� $
��auto ��� $��* �.+��� $*��$Partes con fecha limite esta semana:��$��0�����	#ff2f4f4f$
��Left=�#���  � -   $ 
contenedor��$��1��