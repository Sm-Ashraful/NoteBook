   M S B A M L   `   `   `  ����E  AProject3.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project3._1Project3._1  5          Project3._1.addpass   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Project3._1     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  addpass��5
      .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Add New Password��6   $
��Left=�6:   $��
110,-5,0,0q�6U   $	��Top=�6i   $��30(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ pname��5      )  #MaterialDesignThemes.Wpf.HintAssist   
Foreground
 �   �.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   � *  &MaterialDesignOutlinedTextFieldTextBox#��[  5      $��
22,55,30,0q�5      $	��Top=�5      $��70��5       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5      " �� VerticalScrollBarVisibility$
 Auto=�5         Hint$ Name :��5      	 �� SelectionBrush
	 �   �
 �� 
CaretBrush

 �   �{�5      ��  �� Path$ 	IsChecked� �� ElementName$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox��6�   �� 5   
   -   5        $	 url��5      
 �   �
 �   �#��[  5      $��22,135,30,0q�5      $	��Top=�5       $��70��5!       . $
 Wrap=�5#      $
 Auto=�5$      $ URL :��5%      
	 �   �

 �   �{�5&      �� *	IsChecked+$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox��6�   �� 5'   
   -   5        $
 emun��5'      
 �   �
 �   �#��[  5*      $��22,215,30,0q�5+      $	��Top=�5,      $��70��5-       . $
 Wrap=�5/      $
 Auto=�50      $ UserName/Email :��51      
	 �   �

 �   �{�52      �� *	IsChecked+$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox��6�   � 54   
   $	��124��55      .+�56      �� -   5          MaterialDesignRaisedButton#��[ 57      $
��Auto��58      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��59      $��1,385,-1,10q�5:      
���   �
���   �.��5;      �� $
��Save��5<      ���	#DDFFFFFF$��20(�6*   5=      5>      �� 5?   
   -   5        $ passw��5?      
 �   �
 �   �#��[  5B      $��21,295,29,0q�5C      $	��Top=�5D      $��70��5E       . $
 Wrap=�5G      $
 Auto=�5H      $ 
Password :��5I      
	 �   �

 �   �{�5J      �� *	IsChecked+$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox��6�   5K      5L      