   M S B A M L   `   `   `  ���� b  ^PresentationFramework.Aero2, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  U QSystem.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem  mainWin   mainWin.App   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     <sys,clr-namespace:System;assembly=System.Runtime       �� 	Resources     MidFontSize  BaseFontSize  DobleFontSize  DobleDobleFontSize  
Bordersize  NoHoverButtonStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  NoHoverToggleButtonStyle �� 
TargetType J� SnapsToDevicePixels  listItem  
gridExpand	 N� EnterActions
 �� TargetProperty W� From	 W� To g� Duration N� ExitActions 	 MenuItemStyle 
 loginTextBox  loginTextBox2  ButtonStyleLogin ��Name �� CornerRadius � ColumnDefinitions �� Triggers �� 
TargetName  CircularButtonStyle  TextBoxStyle  RoundButtonStyle3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Opacity  RoundButtonStyle2  RoundButtonStyleConfig)  #System.Windows.Controls.DataGridRow  TarjetaStyle  MinimalDataGridStyle&   System.Windows.Controls.DataGrid  MinimalDataGridHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader  TarjetaStyle2  CabeceraStyle  IconButtonStyle  IconButtonStyle2  IconButtonStyle3  IconButtonStyleMenu  IconButtonStyle4  HoverBorderStyle  HoverBorderStyle3  HoverBorderStyle2  textBoxStyle ��Name   FocusVisual �� StrokeDashArray ! TextBox.Static.Background �� Color " ComboBoxEditableTextBox # ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color � Offset $ ComboBox.Static.Border % ComboBox.Static.Glyph '& #ComboBox.Static.Editable.Background #' ComboBox.Static.Editable.Border .( *ComboBox.Static.Editable.Button.Background *) &ComboBox.Static.Editable.Button.Border !* ComboBox.MouseOver.Background + ComboBox.MouseOver.Border , ComboBox.MouseOver.Glyph *- &ComboBox.MouseOver.Editable.Background &. "ComboBox.MouseOver.Editable.Border 1/ -ComboBox.MouseOver.Editable.Button.Background -0 )ComboBox.MouseOver.Editable.Button.Border 1 ComboBox.Pressed.Background 2 ComboBox.Pressed.Border 3 ComboBox.Pressed.Glyph (4 $ComboBox.Pressed.Editable.Background $5  ComboBox.Pressed.Editable.Border /6 +ComboBox.Pressed.Editable.Button.Background +7 'ComboBox.Pressed.Editable.Button.Border  8 ComboBox.Disabled.Background 9 ComboBox.Disabled.Border : ComboBox.Disabled.Glyph ); %ComboBox.Disabled.Editable.Background %< !ComboBox.Disabled.Editable.Border 0= ,ComboBox.Disabled.Editable.Button.Background ,> (ComboBox.Disabled.Editable.Button.Border ? ComboBoxToggleButton F�Name ^� 
Conditions  �� Binding! �� RelativeSource" �� AncestorType# �� Value$ �� Mode @ ComboBoxEditableTemplate% �Name& �Name' � AllowsTransparency5   /Microsoft.Windows.Themes.SystemDropShadowChrome(  Name)   Color* �� MaxDropDownHeight+ �� ElementName, �� ClearTypeHint- ��Name. ��Name/ ��Name-  'System.Windows.Input.KeyboardNavigation0   DirectionalNavigation1 d�Name2 d� 	IsChecked3 �� Mode4 ��Name5 �� 
IsReadOnly6 P� 
SourceName7 ]� 
Conditions8 �� Property A ComboBoxTemplate9 ��Name#: �� SelectionBoxItemStringFormat; �� ContentStringFormat< �� SelectionBoxItemTemplate= �� SelectionBoxItem> J� IsHitTestVisible B ComboBoxStyle1 C ListBoxItemContainerStyle1? �� 	Resources D Key E MouseOverForegroundBrush��%;  &	        &	      &	      &	 #     &	 /     &	 ;     &	 �     &	 �    &	 M    &		     &	
     &	 �    &	 �    &	 �    &	 "    &	 U	    &	 �
    &	      &	 e    &	     &	 �    &	 �    &	     &	     &	 �    &	 �    &	 H    &	 �    &	 �    &	 8    &	 �    &	 a    &	  �    &	!      &	"     &	# �    &	$ �    &	% �    &	& �    &	'     &	( &    &	) =    &	* T    &	+ �    &	, �    &	- �    &	. �    &	/ �    &	0 R    &	1 g    &	2 �    &	3 �    &	4 �    &	5 �    &	6     &	7 g    &	8 |    &	9 �    &	: �    &	; �    &	< �    &	= �    &	> �    &	?     7 # 7 $ 7 % 7 & 7 ' 7 ( 7 ) 7 , 7 * 7 + 7 - 7 . 7 / 7 0 7 3 7 1 7 2 7 4 7 5 7 6 7 7 7 : 7 8 7 9 7 ; 7 < 7 = 7 > &	@ z(    7 ? 7 ! 7 " &	A /    7 ? &	B 5    7   7 # 7 $ 7 A 7 @ &	C �6    7 E X�5Q�X�20Q�X�40Q�X�60Q�X�70Q��� " ��.���  � ��
 ���� ��  � ��
 ����� P�  �@J�IsMouseOver$
 True��. ���  � �� �#ff6a00��  � �� �#ff6a00�� " d�.���  �@�OverridesDefaultStyle$
 True����  � ��
 ���� ��  � �� �� " d�.R��� #��z��#��z��#��z��$
 True��._��� $��Center=�$��Center=�# z  P�  �@J�IsMouseOver$
 True��. ���  � �� �#ff6a00�� " ��.���  � ��
 �   � P�  �@J�IsMouseOver$
 True��. ���  � �� �#ff6a00�� " � P�  �@J�IsMouseOver$
 True��	 �� .���� .��W� $
 Width� 60 200$ 0:0:0.2D� �� .���� .��W� $
 Width� 200 60$ 0:0:0.2D��� " ��.���  � ��
 ���� ��  � ��$ Disabled=���  � ��$ Disabled=���  � ��$
 left=���  � ��$ Stretch=���  � ��
 �������  � ��$ 50����  � ��$ Stretch=���  � ��$ Center=���  � ��$ 5q��� " ��.���  � ��$ 0,0,0,1q���  � �� �	#80A0A0A0��  � ��$ 10,10,10,20q���  � ��$ 10q���  � ��$ Center=���  � ��
 �������  � ��$ 20(���  � ��$ Center=��� " G�.���  � ��$ 0,0,0,1q���  � �� �	#80A0A0A0��  � ��$ 10,10,10,20q���  � ��$ 10q���  � ��$ Center=���  � ��
 �������  � ��$ 20(���  � ��$ Center=��� " ��.���  � ��
 �������  � �� �� " ��.R�� .+��� $ Border��#��z��#��z��$��0q�$ 5��$y�Visible=�� $��5q� �� $
��Auto ��� $��* �.+��� ���#3fb4c6$��5��$��0��$y�Visible=��� $��1��$��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� $ Border�� � �� �#E6E6E6P�  � ��$
 True��. ��� $ Border�� � �� �#CCCCCC�� $ Border�� � y�$ 	Collapsed=��� $ Border�� � ��$ 0q��� " ��.���  � �� �� " ��.R�� .+�A� ���#3fb4c6�� $��Center=�$��Center=��� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ 0,0,0,1q���  � ��$ 10q���  � ��$ 14(���  � ��$ 33����  � �� �#333333��  � ��$ Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#EAEAEA��  � �� �#fe6701�� " ��.���  � ��
 �������  � ��
 ���� ��  � ��$ 2q���  � ��$ 10q���  � ��$ 16(���  �@J�Effect   $ 10Q�$ 1Q�$	 0.4Q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$ 0��._��� #��z��#��z�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �#ff6a00�� " ��.���  � ��
 �������  � ��
 ���� ��  � ��$ 2q���  � ��$ 10q���  � ��$ 10q���  � ��$ 16(���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$ 5��._��� #��z��#��z�� P�  �@J�IsMouseOver$
 True��. ���  � �� �#EAEAEA�� " �� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �iii���  � ��
 �   ��� "  .���  � ��
 �������  � �� �#f2f2f2��  � ��$ 0q���  � ��$ 0,0,0,10q���  � ��$ 15(���  � ��$ 60����  �@J�Effect   $ 10Q�$ 0Q�$ 0Q� P�  �@J�IsMouseOver$
 True��. ���  �@J�Effect   $ 10Q�$ 5Q�$	 0.5Q�P�  �@ 
IsSelected$
 True��. ���  �@J�Effect   $ 10Q�$ 5Q�$	 0.5Q���  � ��
 �   ��� "  .���  � ��$ 0q���  �@ RowBackground
 ���� ��   �@ AlternatingRowBackground
 ���� ��  �@ GridLinesVisibility$
 None=���  �@ HeadersVisibility$ Column=���  �@ 	RowHeight$ 80Q���  �@ CanUserAddRows$ False����  �@ SelectionMode$ Single=���  �@ 
IsReadOnly$
 True����  � ��
 ���� �� "  .���  � ��
 ���� ��  � ��
 ���� ��  � ��$ 0q���  � ��$ 10q���  � ��$
 Auto����  � ��$ Stretch=���  � ��$ Stretch=���  � ��$ Center=���  � ��$ Center=���  � ��$ 15(���  � ��$
 Bold"��� " ��.���  � ��$ 0q���  � �� �#f2f2f2��  � ��$ 5q���  �@��Padding$ 10q���  � �� �#f2f2f2��  �@��CornerRadius$ 10����  � ��$ 60����  � ��$
 Auto����  �@J�Effect   $ 10Q�$ 0Q�$ 0Q� P�  �@J�IsMouseOver$
 True��. ���  �@J�Effect   $ 10Q�$ 5Q�$	 0.5Q��� " ��.���  � ��$ 0q���  � �� �#a2f2f2��  � ��$ 0q���  �@��Padding$ 10q���  � �� �#a2f2f2��  �@��CornerRadius$ 	10,10,0,0����  � ��$
 Auto����  � ��$
 Auto���� " ��.���  � ��$ Center=���  � �� �� " ��.R��  �� $
��Auto ��� $
��Auto �.+��� $��Center=�$��Center=�$��0���� $��Center=�$��Center=�$��2��$	����$��Segoe MDL2 Assets)�$��10,0,0,0q��� " ��.���  � ��$ Center=���  � �� �� " ��.R��  �� $
��Auto �.+��� $��Center=�$��Segoe MDL2 Assets)�
�������$��Center=�$��0���� " ��.���  � ��$
 Left=���  � �� �� " ��.R��  �� $
��Auto �.+��� $��Center=�$��Segoe MDL2 Assets)�
���   �$��Center=�$��0���� " ��.���  � ��$ Center=���  � �� �� " ��.R��  �� $
��Auto �.+��� $��Center=�$��Segoe MDL2 Assets)�
���   �$��Center=�$��0���� " ��.���  � ��$ 15(���  � �� �	#33ff6a00��  � �� �� " ��.R��  �� $
��Auto �.+��� $��Segoe MDL2 Assets)�$��0���� " ��.���  � ��
 ���� ��  � ��
 ���� ��  � ��$ -5,-5,-5,-5q� P�  �@J�IsMouseOver$
 True��. ���  � �� �	#331A1A1A�� " ��.���  � ��
 ���� ��  � ��
 ����  P�  �@J�IsMouseOver$
 True��. ���  � �� �	#33ff6a00�� " ��.���  � ��
 ���� ��  � ��
 ���� ��  � ��$ -5,-5,-5,-5q� P�  �@J�IsMouseOver$
 True��. ���  � �� �#a2f2f2�� " ��.���  � ��
 ���� ��  � ��
 �������  � ��$ Center=���  � ��$ 5q���  �@��
CaretBrush
 �������  �@��SelectionBrush
 �������  �@��SelectionOpacity$	 0.5Q���  � ��$ 15(���  � �� �� " ��.R��� #��z��#��z��$ 15��._��� $ PART_ContentHost���� .���  � �� �� .R��� $��2q�$	 1 2R�#��� ��$
 true��$��1���� $ 	#FFFFFFFF���� " ��.���  �@�OverridesDefaultStyle$
 true����  �@J�	AllowDrop$
 true����  � ��$ 0����  � ��$ 0����  �@�FocusVisualStyle Z� ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled$ False����  � �� �� " ��.R��� $ PART_ContentHost��
������ $|�false��$��Hidden=�$��Hidden=��� $	 0,1&�$	 0,0&�.��� $ White��$	 0.0Q�� $ White��$	 1.0Q��� $ White���� $ 	#FF606060���� $ 	#FFFFFFFF���� $ 	#FFABADB3���� $ Transparent���� $ Transparent���� $	 0,1&�$	 0,0&�.��� $ White��$	 0.0Q�� $ White��$	 1.0Q��� $ #a2f2f2���� $ 	#FF000000���� $ 	#FFFFFFFF���� $ 	#FF7EB4EA���� $	 0,1&�$	 0,0&�.��� $ 	#FFEBF4FC��$	 0.0Q�� $ 	#FFDCECFC��$	 1.0Q��� $ 	#FF7EB4EA���� $	 0,1&�$	 0,0&�.��� $ White��$	 0.0Q�� $ White��$	 1.0Q��� $ 	#FF569DE5���� $ 	#FF000000���� $ 	#FFFFFFFF���� $ 	#FF569DE5���� $	 0,1&�$	 0,0&�.��� $ 	#FFDAEBFC��$	 0.0Q�� $ 	#FFC4E0FC��$	 1.0Q��� $ 	#FF569DE5���� $ 	#FFF0F0F0���� $ 	#FFD9D9D9���� $ 	#FFBFBFBF���� $ 	#FFFFFFFF���� $ 	#FFBFBFBF���� $ Transparent���� $ Transparent���� " d�.���  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  �@��	ClickMode$ Press=���  � �� �� " d�.R��� $ templateRoot��8��  8�� #��z��$
 true��._��� $ splitBorder��
������ $��1q�$��Right=�$��0q�$
 true��#��� r�._�F� $ arrow��F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��Center=�$��0q�$��Center=� ^�  ��   �� *
IsEditable+! �� "" ��# true��   �� *IsMouseOver+! �� $
$ Self=�	# false��   �� *	IsPressed+! �� $
$ Self=�	# false��   �� *	IsEnabled+! �� $
$ Self=�# true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  �@J�IsMouseOver$
 true��. ��� $ arrow��8   � ��^�  ��   �� *IsMouseOver+! �� $
$ Self=�# true��   �� *
IsEditable+! �� "" ��	# false.0��� $ templateRoot��8   � ���� $ templateRoot��8 	  � ��^�  ��   �� *IsMouseOver+! �� $
$ Self=�# true��   �� *
IsEditable+! �� "" ��# true.0��� $ templateRoot��8 
  � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � ��$
 true��. ��� $ arrow��8   � ��^�  ��   �� *	IsPressed+! �� $
$ Self=�# true��   �� *
IsEditable+! �� "" ��	# false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��   �� *	IsPressed+! �� $
$ Self=�# true��   �� *
IsEditable+! �� "" ��# true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � {�$ false��. ��� $ arrow��8   � ��^�  ��   �� *	IsEnabled+! �� $
$ Self=�	# false��   �� *
IsEditable+! �� "" ��	# false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��   �� *	IsEnabled+! �� $
$ Self=�	# false��   �� *
IsEditable+! �� "" ��# true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ���� " ��.R�� $% templateRoot��$
 true�� �� $��* ��� #��� r�$��0 �.+�� $& 
PART_Popup��$
' true��$��2��$��Bottom=�#��� .����� *IsDropDownOpen+! �� $$ TemplatedParent=�.��  $( shadow��$) Transparent��#��z* ���� *ActualWidth+$+ templateRoot��._��� $ dropDownBorder��#��� ��#��� ��$��1q�._��� $ DropDownScrollViewer��.��� $
% grid��$, Enabled=�.+��� $- canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $. 
opaqueRect������ *
Background+$+ dropDownBorder������ *ActualHeight+$+ dropDownBorder������ *ActualWidth+$+ dropDownBorder���� $/ ItemsPresenter��$0 	Contained=�# z d� $1 toggleButton��#��z��#��z��#��z��$��2��8��  2 �� *IsDropDownOpen+$3 TwoWay=�! �� $$ TemplatedParent=��� $ border��8�� #��z��._��� $4 PART_EditableTextBox��#��z��#��z��8�� #��z��5 �� *
IsReadOnly+! �� $$ TemplatedParent=� P�  � {�$ false��. ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsKeyboardFocusWithin$
 true��. ���  � ��
 �   �P� $6 
PART_Popup�� �@�HasDropShadow$
 true��. ��� $ shadow�� � ��$ 0,0,5,5q��� $ shadow�� �@ Color$ 	#71000000��P�  �@��HasItems$ false��. ��� $ dropDownBorder�� � ��$ 95��]� 7 �� 8 �@��
IsGrouping$
# true���� "8 �@%�IsVirtualizingWhenGrouping$# false��./���  � ��$ false��P� $6 DropDownScrollViewer�� � ��$ false��. ��� $ 
opaqueRect�� �� *VerticalOffset+$+ DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$+ DropDownScrollViewer�� �@��Left�� " ��.R�� $% templateRoot��$
 true�� �� $��* ��� #��� r�$��0 �.+�� $& 
PART_Popup��$
' true��$��2��$��1q�$��Bottom=�#��� .����� *IsDropDownOpen+$3 TwoWay=�! �� $$ TemplatedParent=�.��  $( shadow��$) Transparent��#��z* ���� *ActualWidth+$+ templateRoot��._��� $ dropDownBorder��#��� ��#��� ��$��1q�._��� $ DropDownScrollViewer��.��� $
% grid��$, Enabled=�.+��� $- canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $. 
opaqueRect������ *
Background+$+ dropDownBorder������ *ActualHeight+$+ dropDownBorder������ *ActualWidth+$+ dropDownBorder���� $/ ItemsPresenter��$0 	Contained=�# z d� $1 toggleButton��#��z��#��z��#��z��$��2��8��  2 �� *IsDropDownOpen+$3 TwoWay=�! �� $$ TemplatedParent=��� $9 contentPresenter��#; z: #��z< #��z= #��z��#��z��$> false��#��z��# z #��z�� P� $6 
PART_Popup�� �@�HasDropShadow$
 true��. ��� $ shadow�� � ��$ 0,0,5,5q��� $ shadow�� �@ Color$ 	#71000000��P�  �@��HasItems$ false��. ��� $ dropDownBorder�� � ��$ 95��]� 7 �� 8 �@��
IsGrouping$
# true���� "8 �@%�IsVirtualizingWhenGrouping$# false��./���  � ��$ false��P� $6 DropDownScrollViewer�� � ��$ false��. ��� $ 
opaqueRect�� �� *VerticalOffset+$+ DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$+ DropDownScrollViewer�� �@��Left�� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$
 Auto=���  � ��$
 Auto=���  � ��$ 6,3,5,3q���  � ��$
 true����  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled$ False����  � ��8   P�  �@��
IsEditable$
 true��. ���  � ��$ false����  � ��$ 2q���  � ��8  �� " ��? ���� MouseOverForegroundBrushD $ #ff6a00��.���  � ��
 �   ���  �@�FocusVisualStyle Z�  P�  �@J�IsMouseOver$
 True��. ���  � ��
 ���� ��  � ��
 �������  � ��$ 0q���  � ��8   