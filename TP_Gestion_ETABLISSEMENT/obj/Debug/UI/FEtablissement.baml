   M S B A M L   `   `   `  ����S  OTP_Gestion_ETABLISSEMENT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TP_Gestion_ETABLISSEMENT.UITP_Gestion_ETABLISSEMENT.UI  5   	   0    *TP_Gestion_ETABLISSEMENT.UI.FEtablissement   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:TP_Gestion_ETABLISSEMENT.UI     5   	     � Title$  FEtablissement��5   	   $��397.207��6    $��1011.51��61   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Nom de l'établissement��6   $
��Left=�6@   $��	69,39,0,0q�6[   $	��Top=�6n   �� 5   
   -   5         ��Name$ nom_txt��5      $
��Left=�6#   $��23��6>   $��	69,98,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��250��6�   �� 5   
   -   5        $ label1��5      $��Ville de l'établissement��6    $
��Left=�6C   $��
69,141,0,0q�6^   $	��Top=�6r   �� 5   
   -   5        $ 	ville_txt��5      $
��Left=�6%   $��23��6@   $��
69,192,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��250��6�   �� 5   
   -   5        $ label2��5      $%��Téléphone de l'établissement��6    $
��Left=�6G   $��
69,241,0,0q�6b   $	��Top=�6v   �� 5   
   -   5        $ tel_txt��5      $
��Left=�6#   $��23��6>   $��
69,288,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��250��6�   �� 5   
   -   5         ��Name$ valider��5      $��Valider��6"   $
��Left=�64   $��139,337,0,0q�6O   $	��Top=�6d   $��75��6|   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��
343,39,0,0q�6@   $	��Top=�6T   $	��272��6l   $	��661��6y      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID de l'établissement��6<   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *Id+6<     5      $ Nom de l'établissement��6>   	 6%   �� *NomE+6>     5      $ Ville de l'établissement��6@   	 6%   �� *VilleE+6@     5      $% Téléphone de l'établissement��6>   	 6%   �� *TelE+6>     5      $ ID de l'utilisateur��6@   	 6%   �� *IdU.Id+6@   5      �� 5   
   -	   5        $ connexion_params��5      $�� ��6*   $
��Left=�66   $��
624,10,0,0q�6Q   $	��Top=�6e   $	��312��6}   5      5      