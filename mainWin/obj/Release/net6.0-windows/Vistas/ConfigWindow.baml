   M S B A M L   `   `   `  ���� B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1      WpfApp1.ConfigWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:WpfApp1     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/    � Title$  config�� � WindowStartupLocation$ CenterScreen=�
������  � WindowStyle$
 None=� � AllowsTransparency$
 True��$	��720��$
��1080��.��� 
������ .+���  �� Padding$	 100q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 1Q�   Color$ Black��   Opacity$ 1Q�	   
BlurRadius$	 50Q�._��� 
�������
 �� CornerRadius$
 10��$	��500��$	��500��$��1��._��  � RowDefinitions �� $
��Auto ��� $��2* ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�$��10q�$
��Left=�.+��� $��Configuracion:��$��20(��� $��0��$��1��$��10q�$ 
Horizontal=�$��Right=�.+��� -      IconButtonStyle3#��[  $	����$��5q��� $��1��$��10q�.+��� $��	Servidor:���� -    ��Name$ ServidorTextBox��  TextBoxStyle#��[ �� $��Usuario:��$��0,10,0,0q��� -   $ UsuarioTextBox��#��[ �� $��Contraseña:��$��0,10,0,0q��� -   $ PassTextBox��#��[ �� -   $��Guardar��$��3��  RoundButtonStyle2#��[ $��10q��� -   $��Cancelar��$��3��$��1��#��[ ���#fe6701$��10q��� $��1��$��Center=�$��Center=�$��1��.+��� -    ��Name$ 
borderProb�����#91d0dd  RoundButtonStyleConfig#��[ $��30��$	��150��$��10q�$��Probar conexión���� -   $ 	borderGen�����#fca47c#��[ $��Generar BBDD��$	��150��$��30��$��10q��� -	   $ borderInstall�����#f7c292#��[ $	��150��$��Instalar mysql��$��30��$��10q�