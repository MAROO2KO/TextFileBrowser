   M S B A M L   `   `   `  ����J  FTextFileBrowser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TextFileBrowserTextFileBrowser  5   	        TextFileBrowser.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:TextFileBrowser     5   	   a ]ActiproSoftware.Gauge.Wpf, Version=22.1.4.0, Culture=neutral, PublicKeyToken=36ff2196ab5654b9?gauge3http://schemas.actiprosoftware.com/winfx/xaml/gauge  5   	     � Title$  TextFileBrowser��5	   	   $	��400��6!   $
��1000��6.   $	��400��6;   $
��1000��6K   $
��1000��6~   ��6[   �� *ScreenHeight+.��5
      � $��0,0,0,0q�6   .+�5   
   �� -   5         ��Name$ checkFolder��5      $��Adresár��6A    � ToolTip$; 5Ak chceme prehľadávať textové súbory v adresári��6S   $
��Left=�6�   $��
373,14,0,0q�6�   $	��Top=�6�   $��20��6�   $
��Auto��6�    J� RenderTransformOrigin$ 	-0.7,0.65&�6�   6-  �� 5   
   -   5        $ checkRecurse��5      {�.  $��Podadresáre��6;   $C =Ak chceme prehľadávať textové súbory aj v podadresároch��6Q   $
��Left=�6�   $��
373,34,0,0q�6�   $	��Top=�6�   $��20��6�   $
��Auto��6�   $ 	-0.7,0.65&�6�   �� 5   
   -   5        $ 	checkFile��5      $��Súbor��6&   $9 3Ak chceme prehľadávať konkrétny textový súbor��66   $
��Left=�6n   $��
527,22,0,0q�6�   $	��Top=�6�   $��20��6�   $
��Auto��6�   $ 	-0.7,0.65&�6�   6  �� 5   
   $
��Left=�6   $��
392,67,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��23��6o   $	��280��6{   $ 0.545,0.486&�6�   �� 6�   $
�Sem ��6�   �� 6�   $�zadajte cestu k adresáru��6�   �� 6�    � Language$ en-gb�6�   $� / súboru:��6�   6  �� 5   
   -   5         ��Name$ 
searchPath��5      $��Center=�6&   $��0,90,0,0q�6C    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $��23��6�   $	��560��6�   $ 0.491,0.606&�6�   �� 5   
   -   5         ��Name$ chooseFileBtn��5      {�.  $��Vybrať��6:   $��Right=�6K   $��	0,90,90,0q�6g   $��23��6z   $	��100��6�   $	��Top=�6�   6�   �� 5   
   $��Center=�6   $��	0,120,0,0q�61   $
��Wrap=�6D   $%��Sem napíšte hľadaný výraz:��6X   $	��Top=�6z   $��23��6�   $	��152��6�   $ 0.545,0.486&�6�   �� 5   
   -   5        $ 	searchKey��5      $��Center=�6%   $��23��6B   $��	0,142,0,0q�6N   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��560��6�   �� 5   
   -   5        $ 	searchBtn��5      {�.  $��Hľadať��66   $��Right=�6G   $��
0,142,90,0q�6c   $	��Top=�6w   $	��100��6�   $��23��6�   6�   �� 5   
   -   5        $ 	resultBox��5      $��Center=�6%   $��
0,200,0,30q�6B   $ NoWrap=�6V   $�� ��6l   $��Stretch=�6t   $	��560��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $	 �� HorizontalScrollBarVisibility$
	 Auto=�6�   �� 5   
   -	   5        $ copyBtn��5      $��Kopírovať��6"   $��Right=�66   $��
0,217,90,0q�6R   $	��Top=�6f   $	��100��6~   $��23��6�   $ -0.121,-0.694&�6�   6�   5      5      