   M S B A M L   `   `   `  ���� B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1      WpfApp1.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:WpfApp1     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/    � Title$  
MainWindow�� � WindowStartupLocation$ CenterScreen=�
������  � WindowStyle$
 None=� � AllowsTransparency$
 True��$	��720��$
��1080�� � 	Resources    animate �� 
TargetType �� Triggers P� Property P� Value	 N� EnterActions
 �� TargetProperty W� From	 W� To g� Duration N� ExitActions��%�   &	        �� " � P�  � y�$ Visible=�	 �� .���� .��W� $
 Width� 0 500$ 0:0:0.2D� �� .���� .��W� $
 Width� 500 0$ 0:0:0.2D�.��� 
������  � ColumnDefinitions �� $��10 ��� $
��auto ��� $��* ��� $
��auto ��� $��10 � � RowDefinitions �� $��40 ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��40 �.+��� $��2�� �� Padding$ 20q�$��12��$��1�����#3fb4c6
������� �� CornerRadius$ 	10,0,0,10��._�� -    �Name$ inciosesion��#��[  $y�	Collapsed=� �� $��* � �� $��* �.+�� $��Center=�$��Center=�.+��� .+��� $��Ya tienes cuenta?�����#dfdddc$��20q�$��60(��� $`��ZEl taller te espera. Inicia sesión y retoma el control de tus reparaciones informáticas.��$��14(�$��20q����#dfdddc$
��Wrap=��� -    ��Name$ iniciarsesion��$��Iniciar Sesion��$��16(�$��20q����#dfdddc���#dfdddc���	#953fb4c6$	��120��$��40���� -    ��Name$ 	BorderReg��$��2��$��12��$ 20q�$��3�����#3fb4c6
�������$ 	0,10,10,0��._�� -   $ registro��#��[   �� $��* � �� $��* �.+�� $��Center=�$��Center=�.+��� .+��� $��Registrarse�����#dfdddc$��20q�$��60(��� $n��hTransforma tus reparaciones. Regístrate y gestiona tus órdenes de trabajo informáticas con facilidad.��$��14(�$��20q����#dfdddc$
��Wrap=��� -   $ registrarse��$��Registrarse��$��16(�$��20q����#dfdddc���#dfdddc���	#953fb4c6$	��120��$��40��� -   $ central��$��1��$��14��$��2��
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 50Q�   Color$ Black��.+�� -   $ gridCentroRegistro��$y�	Collapsed=�.+��� $��Registro��$��32(�
�������$
��Left=�$	��Top=�$��
30,20,0,40q��� $��Center=�$��Center=�$	��400��.+��� -    ��Name$ regUser��  loginTextBox#��[ $��Usuario���� -	   $ regnom��#��[ $��Nombre���� -
   $ regmail��$��Email��#��[ G� -    G�Name$ regPass��  loginTextBox2#��[ �� -   $ 	registrar��$��	Registrar��$��50��$	��100��$��Right=�$��40q����#3fb4c6
����������#3fb4c6� -   $ gridCentroInicio��.+��� $��Iniciar Sesion��$��32(�
�������$
��Left=�$	��Top=�$��
30,20,0,40q��� $��Center=�$��Center=�$	��400��.+��� -   $ textuserIni��#��[ $��Usuario��G� -   $ textpassIni��#��[ �� -   $ btnInicioSesion��$��Iniciar Sesion��$��40��$	��100��$
��Left=�$��40q����#3fb4c6
����������#3fb4c6�� -   $��Right=�$��40q�$��Bottom=�.+�"  FontAwesome.WPF.ImageAwesome     Icon$
 Gear=�$��Center=�$��Center=�$��50��$��40��   
Foreground
 �����$��5q�