Git
 "<tipo> <arquivo ou domino> <comentario>"
 

-func - novas funções  

-fix => para correção de bugs  

-edit => edição de nome de classe, função ou arquivo

-addfile => adiciona arquivo
-refactor => refatoração  

-config => configurações que não alteram  

-remove  
... -f => remoção de arquivo  
... -c => classe   
... -var => variavel     


Ex: git commit -m -func - "CadastroBasico - icluindo novo campo idade" Ex: git commit -m "refactor - App.vue - trocando ordem das opçoes"

Funções, propriedades e classes:
C# - Primeira Maiuscula JS - Minuscula


CSS
OBS: usar classes sempre que possível -classe: RSCSS ex: form-busca


prefixo: SD - para componentes costumizados - Ex SDHeader

Ordem preferencial de declaração do componente Vue(Ver style guide, regra 1 prioridade C)

name
components
props
data
computed
watch
Lifecycle hooks em ordem de chamada:
beforeCreate, created, beforeMount, mounted, beforeUpdate, updated, activated, deactivated, beforeDestroy, destroyed
methods
