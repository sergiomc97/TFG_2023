   M S B A M L   `   `   `  ����B  >mainWin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mainWin.VistasmainWin.Vistas  5      /clr-namespace:mainWin.VistasmainWin.Vistas  5      #    mainWin.Vistas.DetallesWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +ucclr-namespace:mainWin.Vistas     5      .localclr-namespace:mainWin.Vistas     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      -   5          N� Title$  
Pendientes��5      .��5      � -   5        .+�5   
   � -   5         �Name$ 	principal��5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      � -   5        $ control��5      $��0��5         
gridExpand#��[  5      $��60��5      5!      � 5"      -   5        $ expandedContent��5"      $��1��5#      ���#E0E0E0.+�5'      �  � RowDefinitions 5(      �� 5*      $
��Auto �6(   �� 5+      $
��Auto �6(   �� 5-      $��* �6(   .+�51      �� $��0��6   ���#108aa4$��60��53       �� Padding$ 10q�54      ._�55      �  56      �� 57   "   $��* �63   �� 58   "   $��* �63   �� 59   "   $��* �63   .+�5<      �� -   5         ��Name$ backBtn��5=   %   $
��Left=�5<   %   $��0��5>   %   $��10q�5?   %     IconButtonStyle2#��[ 5@   %   $	����5A   %   5B   %   5C      5D      � 5G      $��1��6   $��10q�5H      
������  5J      �� 5K      $��* �6/   �� 5L      $��* �6/   �� 5M      $��* �6/   �� 5N      $��* �6/   �� 5O      $��* �6/   �� 5P      $��* �6/   .+�5R      �� $��0��6$   $��Editar Orden��5S   $     DobleFontSize#���  5T   $   �� 5V      -   5        ���	#331A1A1A$��5��5W   !    �� CornerRadius$ 20��5X   !   $ 5q�5Y   !     
Bordersize#���  5Z   !   ._�5\      �� $��Guardar��6(   
�������$��Center=�5^   (   $��Center=�5_   (     BaseFontSize#���  5`   (   5a      5b      � 5e      $��2��6    5f      �� 5g      $��* �6/   �� 5h      $��* �6/   �� 5i      $��* �6/    5k      �� 5l      $��* �6,   �� 5m      $��* �6,   �� 5n      $��* �6,   �� 5o      $��* �6,   �� 5p      $��* �6,   �� 5q      $��* �6,   .+�5u      �� $��10q�6!   $ 10��5v   !   
�������$��3��5x   !   $��0��5y   !   $��0��5z   !   ._�5|      �  5}   "   �� 5~   &   $��* �67   �� 5   &   $��* �67   �� 5�   &   $��* �67   �� 5�   &   $��* �67   �� 5�   &   $��* �67   �� 5�   &   $��* �67   �� 5�   &   $��* �67    5�   "   �� 5�   &   $��* �64   .+�5�   "   ��  �� Orientation$ 
Horizontal=�6-   $��Center=�5�   -   $��0��5�   -   $��2��5�   -   $��1��5�   -   .+�5�   &   �� $��ID de Orden:��60   $��5q�5�   0   #���  5�   0   $
��Bold"�5�   0   �� 5�   &   -   5         ��Name$ textId��5�   0   $��5q�5�   0   #���  5�   0   $��Light"�5�   0   ��5�   0   �� *	IdOrden+5�   0   5�   #   �� 5�   "   $ 
Horizontal=�6-   $��Center=�5�   -   $��1��5�   -   $��2��5�   -   $��2��5�   -   .+�5�   &   �� $��Fecha:��60   $
��Bold"�5�   0   $��5q�5�   0   #���  5�   0   �� 5�   &   -	   5        $ 	textfecha��5�   0   $��5q�5�   0   #���  5�   0   $��Light"�5�   0   ��5�   0   �� *Fecha+5�   0   5�   #   �� 5�   "   -
   5        	 ��Name$	 borderPorPresupuestar��5�   )   ���#91d0dd$��4��5�   )   $��3q�5�   )   
������ $��1��5�   )   #���  5�   )   $ 20��5�   )   $ 5q�5�   )   ._�5�   &   �� $��Por presupuestar��60   $��Center=�5�   0   $��Center=�5�   0   
�������$
��Bold"�5�   0   #���  5�   0   5�   #   �� 5�   "   -   5        $	 borderEnProceso��5�   )   ���#fca47c$��5��5�   )   $��1��5�   )   $��3q�5�   )   
������ $ 20��5�   )   #���  5�   )   $ 5q�5�   )   ._�5�   &   �� $��
En proceso��60   $��Center=�5�   0   $��Center=�5�   0   
�������$
��Bold"�5�   0   #���  5�   0   5�   #   �� 5�   "   -   5        $	 borderPorEntregar��5�   )   ���#f7c292$��6��5�   )   $��3q�5�   )   
������ $��1��5�   )   #���  5�   )   $ 20��5�   )   $ 5q�5�   )   ._�5�   &   �� $��Por entregar��60   $��Center=�5�   0   $��Center=�5�   0   
�������$
��Bold"�5�   0   #���  5�   0   5�   #   5�      5�      �� 5�      $��10q�6!   $��5��5�   !   $��1��5�   !   $ 10��5�   !   $��2��5�   !   
�������$��0��5�   !   ._�5�      �  5�   "   �� 5�   &   $��* �67   �� 5�   &   $��* �67   �� 5�   &   $��* �67   �� 5�   &   $��* �67    5�   "   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5   &   $��* �64   �� 5  &   $��* �64   �� 5  &   $��* �64   .+�5  "   �� $��Dispositivo:��6,   $��0��5  ,   $��0��5  ,   #���  5  ,   $
��Left=�5	  ,   $��10,0,0,0q�5
  ,   $
��Bold"�5  ,   $��Center=�5  ,   �� 5  "   -   5        
 ��Name$
 
textModelo��5  *   $��0��5  *   $��1��5  *   #���  5  *    �� TextWrapping$
 Wrap=�5  *   $��
ExtraLight"�5  *   $��0,0,0,1q�5  *   
�������$��10,0,0,0q�5  *   $��Center=�5  *   ��5  *   �� *Modelo+5  *   �� 5  "   $��Averia:��6,   $��Center=�5  ,   $��0��5  ,   $��10,0,0,0q�5  ,   #���  5  ,   $
��Bold"�5  ,   $��2��5  ,   �� 5!  "   -   5        $
 
textAveria��5$  *   $��0��5"  *   $��3��5#  *   $��2��5%  *   $��3��5&  *   #���  5'  *   $
 Wrap=�5(  *   $��
ExtraLight"�5)  *   $��0,0,0,1q�5*  *   
�������$��10,0,0,0q�5,  *   ��5!  *   �� *Averia+5,  *   �� 5.  "   $��	Solucion:��6,   $��Center=�5/  ,   $��0��50  ,   $��10,0,0,0q�51  ,   $
��Bold"�52  ,   #���  53  ,   $��5��54  ,   �� 56  "   -   5        $
 textSolucion��59  *   $��0��57  *   $��3��58  *   $��2��5:  *   $��6��5;  *   #���  5<  *   $
 Wrap=�5=  *   $��
ExtraLight"�5>  *   
������ $��10,0,0,0q�5@  *   ��56  *   �� *
Solucion+5@  *   �� 5B  "   $��Observaciones:��6,   $��Center=�5C  ,   $��0��5D  ,   $��10,0,0,0q�5E  ,   #���  5F  ,   $
��Bold"�5G  ,   $��8��5H  ,   �� 5J  "   -   5        $
 textobs��5M  *   $��0��5K  *   $��3��5L  *   $��2��5N  *   $��9��5O  *   #���  5P  *   $
 Wrap=�5Q  *   $��
ExtraLight"�5R  *   $��0,0,0,1q�5S  *   
�������$��10,0,0,0q�5U  *   ��5J  *   �� *Observaciones+5U  *   5V     5X     �� 5Z     $��10q�6!   $��1��5[  !   $��2��5\  !   $ 10��5]  !   
�������$��2��5_  !   ._�5`     � $��30q�6#    5a  "   �� 5b  &   $��* �67   �� 5c  &   $��* �67    5f  "   �� 5g  &   $��2* �64   �� 5h  &   $��10 �64   �� 5i  &   $��2* �64   �� 5j  &   $��10 �64   �� 5k  &   $��2* �64   �� 5l  &   $��10 �64   �� 5m  &   $��2* �64   �� 5n  &   $��10 �64   .+�5t  "   �� $��Cliente:��6,   $��0��5u  ,   $��0��5v  ,   #���  5w  ,   $
��Left=�5x  ,   $
��Bold"�5y  ,   $��10,0,0,0q�5z  ,   $��Center=�5{  ,   �� 5~  "   -   5        $
 textCliente��5�  *   $��0��5  *   $��1��5�  *   #���  5�  *   $
 Wrap=�5�  *   $��10,0,0,0q�5�  *   $��
ExtraLight"�5�  *   $��0,0,0,1q�5�  *   
���������5~  *   �� *Cliente.Nombre+5�  *   �� 5�  "   $��	Telefono:��6,   $��2��5�  ,   $��0��5�  ,   #���  5�  ,   $
��Left=�5�  ,   $��10,0,0,0q�5�  ,   $
��Bold"�5�  ,   $��Center=�5�  ,   �� 5�  "   -   5        $
 textTelefono��5�  *   $��2��5�  *   $��1��5�  *   #���  5�  *   $
 Wrap=�5�  *   $��
ExtraLight"�5�  *   $��10,0,0,0q�5�  *   $��0,0,0,1q�5�  *   
���������5�  *   �� *
Telefono+5�  *   �� 5�  "   $��Dirección:��6,   $��4��5�  ,   $��0��5�  ,   #���  5�  ,   $
��Left=�5�  ,   $��10,0,0,0q�5�  ,   $
��Bold"�5�  ,   $��Center=�5�  ,   �� 5�  "   -   5        $
 	textDirec��5�  *   $��4��5�  *   $��1��5�  *   $��2��5�  *   #���  5�  *   $
 Wrap=�5�  *   $��10,0,0,0q�5�  *   $��
ExtraLight"�5�  *   $��0,0,0,1q�5�  *   
���������5�  *   �� *Cliente.Direccion+5�  *   �� 5�  "   $
��DNI:��6,   $��6��5�  ,   $��0��5�  ,   #���  5�  ,   $
��Left=�5�  ,   $��10,0,0,0q�5�  ,   $
��Bold"�5�  ,   $��Center=�5�  ,   �� 5�  "   -   5        $
 textdni��5�  *   $��6��5�  *   $��1��5�  *   $��2��5�  *   #���  5�  *   $
 Wrap=�5�  *   $��10,0,0,0q�5�  *   $��
ExtraLight"�5�  *   $��0,0,0,1q�5�  *   
���������5�  *   �� *Cliente.Dni+5�  *   5�     5�     �� 5�     $��10q�6!   $��3��5�  !   $��3��5�  !   $ 10��5�  !   
�������$��2��5�  !   ._�5�     �  5�  "   �� 5�  &   $��* �67   �� 5�  &   $��* �67    5�  "   �� 5�  &   $��* �64   �� 5�  &   $��* �64   �� 5�  &   $��* �64   �� 5�  &   $��* �64   �� 5�  &   $��* �64   �� 5�  &   $��* �64   �� 5�  &   $��* �64   �� 5�  &   $��* �64   �� 5�  &   $��* �64   �� 5�  &   $��* �64   .+�5�  "   �� $��	Detalles:��6,   $��0��5�  ,   #���  5�  ,   $
��Left=�5�  ,   $��10,0,0,0q�5�  ,   $
��Bold"�5�  ,   $��Center=�5�  ,   �� 5�  "   $��Fecha Compromiso:��6,   $��0��5�  ,   $��10,0,0,0q�5�  ,   #���  5�  ,   $��2��5�  ,   $
��Bold"�5�  ,   (  "System.Windows.Controls.DatePicker  5�  "   $��1��5�  -   #���  5�  -   $��2��5�  -      SelectedDate 5�  -   �� *
Fecha_comp+5�  -   �� 5   "   $��
Prioridad:��6,   $��0��5  ,   $��4��5  ,   #���  5  ,   $��10,0,0,0q�5  ,   $
��Bold"�5  ,   �� 5  "   -   5         ��Name$ 	comboprio��5  +     ComboBoxStyle1#���  5  +   #���  5	  +   $��1��5
  +   $��4��5  +   .@�5  &   �� .��63   Alta69   �� 5  &   .��63   Media6:   �� 5  &   .��63   Baja69   5  #   �� 5  "   $��Asignado a:��6,   $��0��5  ,   $��6��5  ,   #���  5  ,   $��10,0,0,0q�5  ,   $
��Bold"�5  ,   �� 5  "   -   5        $ 	comboAsig��5  +   $��1��5  +   #���  5  +    �� DisplayMemberPath$ Nombre��5  +   #���  5  +    �� SelectedValuePath$ 
IdEmpleado��5  +   $��6��5  +   5  #   5!     5#     5%     5'     5)     5+     5-     5/     