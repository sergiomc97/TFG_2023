   M S B A M L   `   `   `  ���� B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mainWin.VistasmainWin.Vistas  /clr-namespace:mainWin.VistasmainWin.Vistas  "    mainWin.Vistas.ConfiguWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:mainWin.Vistas     +ucclr-namespace:mainWin.Vistas     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/    N� Title$  ServiciosWindow��.��� -    � ColumnDefinitions �� $
��Auto ��� $��* �.+�� -    �Name$ control��$��0��   
gridExpand#��[  $��60��� -   $ expandedContent��$��1�����#E0E0E0.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��60�����#FFAE74 �� Padding$ 10q�._��  �� $��* ��� $��* ��� $��* �.+��� -    ��Name$ backBtn��$
��Left=�$��0��$��10q�  IconButtonStyle2#��[ $	������ $��2��$��10q� �� CornerRadius$ 10��
�������._��  �� $��* ��� $��* ��� $��* ��� $��* �.+�� $��0��$��Center=� �� $��* ��� $��* ��� $��* �.+��� $ ��Seleccionar base de datos:��$��0��$
��Left=�$��Center=��� -    ��Name$ txtRutaArchivo�� �� 
IsReadOnly$
 True��$��1��  loginTextBox#��[ $
��Left=�$��Center=��� -   $��Seleccionar Archivo��$��40��$��2��$	��150��$��Right=�$��Center=����#3fb4c6
����������#3fb4c6� $��1��$��Center=� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Asignar el usuario:��$��0��$��Center=�$��15(�$��Light"��� -   	 ��Name$	 combo��$��1��$	��100��$��Center=�  ComboBoxStyle1#���  �� $��Al empleado:��$��2��$��Center=�$��15(�$��Light"��� -   $	 combo2��$��3��$	��100��$��Center=�#���  �� -	   $ asign��$��Asignar��$��4��$��40��$	��150��$��Right=�$��Center=����#3fb4c6
����������#3fb4c6� $��2��$��Center=� �� $
��auto ��� $
��auto �.+��� $��Cargar datos de factusol:��$��0��$��Center=�$��15(�$��Light"��� -
   $ cargar��$��Cargar��$��1��$��40��$	��150��$��40,0,0,0q�$��Right=�$��Center=����#3fb4c6
����������#3fb4c6�� $��10q�$��Bottom=�$��3��$��Right=�.+��� -   $ 
SaveButton��  RoundButtonStyle#��[ ���#3fb4c6.���� $��Guardar��  BaseFontSize#���  $��10q�