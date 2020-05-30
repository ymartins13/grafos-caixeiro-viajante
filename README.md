# Grafos - O Problema do Caixeiro Viajante

Aplicação construída com .net Core, para execução de Heurística do vizinho mais próximo.

Arquivos de entrada:

* trechos: arquivo contendo os vértices e as distâncias entre eles (separados por espaço). Exemplo:
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
* origem/destino: arquivo contendo os vértices de origem e destino. Exemplo:
  ```sh
  SF WS
  LS BC
  WS BC
  ```
Arquivo de saída:
* rotas: arquivo contendo o melhor caminho identificado pela heurística para o vértices de origem/destino, e a distância total. Exemplo:
  ```sh
  SF WS 1
  LS LV BC 2
  WS SF LV BC 5
  ```
