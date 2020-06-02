# Grafos - Encomendas - Heurística do vizinho mais próximo

Aplicação construída com .net Core (C#), para execução de Heurística do vizinho mais próximo (Dijkstra).

A solução se baseia no percorrer da lista de arestas (trechos), buscando sempre, entre as opções, o trecho de menor custo, sem passar por pontos já visitados.

Arquivos de entrada: os arquivos de entrada devem ser disponibilizados na pasta "Dados", na raiz do projeto. 

* trechos: arquivo contendo os nodos e as distâncias entre eles (separados por espaço). Exemplo:
  ```sh
  LS SF 1
  SF LS 2
  LS LV 1
  LV LS 1
  SF LV 2
  LV SF 2
  LS RC 1
  RC LS 2
  SF WS 1
  WS SF 2
  LV BC 1
  BC LV 1
  ```
* encomendas: arquivo contendo os nodos de origem e destino. Exemplo:
  ```sh
  SF WS
  LS BC
  WS BC
  ```
Arquivo de saída: o arquivo de saída será gerado na pasta "Dados", na raiz do projeto. 

* rotas: arquivo contendo o melhor caminho identificado pela heurística para os nodos de origem/destino, e a distância total (custo). Exemplo:
  ```sh
  SF WS 1
  LS LV BC 2
  WS SF LV BC 5
  ```
