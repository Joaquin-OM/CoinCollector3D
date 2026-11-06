# Coin Collector 3D — Pràctica UF2 (Nucli del joc - PF 1/3)

**Alumne:** Joaquin Oses Monti  
**Assignatura:** Desenvolupament de Videojocs (UF2 — Programació del jugador en 3D)  
**Motor:** Unity 6 LTS (`6000.6.3f1`) · C#

---

## 1. Descripció del projecte

Nucli jugable del **Coin Collector 3D** (primer lliurament del projecte final, P1/3):
- Una esfera controlada pel jugador es mou amb física (`Rigidbody.linearVelocity` dins de `FixedUpdate`) sobre un nivell (`Ground`, `Tag = Ground`) tancat per **4 parets invisibles** (`MeshRenderer` desactivat i `Is Trigger = true`) i una **KillZone** inferior.
- El nivell conté **8 monedes** instanciades a partir del Prefab `Coin.prefab` amb animació de rotació sobre l'eix Y i flotació vertical (`Mathf.PingPong`).
- Quan el jugador recull una moneda (`OnTriggerEnter`), se suma **+1 punt** al `GameManager` (patró *Singleton*), la moneda es destrueix (`Destroy(gameObject)`) i es mostra per Console `"Coin collected! Score: X"`.
- Si la bola cau fora del nivell i entra a la `KillZone`, es mostra `"Player killed!"` a la Console i es reinicia l'escena actual (`RestartLevel()`).
- Inclou l'escena `MenuPrincipal.unity` amb un `Canvas` i el botó **"Play"** configurat per carregar `Level1.unity`.

---

## 2. Estructura de carpetes

```text
Assets/
├── Scenes/
│   ├── MenuPrincipal.unity
│   └── Level1.unity
├── Scripts/
│   ├── PlayerController.cs
│   ├── Coin.cs
│   ├── KillZone.cs
│   ├── GameManager.cs
│   └── Spinner.cs
├── Prefabs/
│   └── Coin.prefab
└── Materials/
    ├── CoinMaterial.mat
    ├── GroundMaterial.mat
    └── PlayerMaterial.mat
```

---

## 3. Resum dels Scripts i Ampliacions (+2 punts)

| Script | GameObject | Funció principal |
| :--- | :--- | :--- |
| `PlayerController.cs` | `Player` (`Tag = Player`) | Llegeix els eixos `Horizontal` i `Vertical` (WASD / fletxes) i aplica `rb.linearVelocity` a `FixedUpdate` conservant `rb.linearVelocity.y`. Velocitat `speed` amb `[SerializeField]`. Rotació bloquejada en X i Z (`Freeze Rotation X, Z`). |
| `Coin.cs` | Prefab `Coin` | Detecta el jugador amb `OnTriggerEnter` (`CompareTag("Player")`), suma +1 punt cridant `GameManager.Instance.AddScore(1)` i destrueix la moneda amb `Destroy(gameObject)`. |
| `GameManager.cs` | `GameManager` | Implementa el patró **Singleton** (`GameManager.Instance`), desa la puntuació (`score`), imprimeix `"Coin collected! Score: X"` a `AddScore(int points)` i reinicia l'escena amb `SceneManager.LoadScene(GetActiveScene().buildIndex)`. |
| `KillZone.cs` | `KillZone` | Detecta l'entrada del jugador (`OnTriggerEnter`), escriu `"Player killed!"` a la Console i crida `GameManager.Instance.RestartLevel()`. |
| `Spinner.cs` *(+2 pts)* | Prefab `Coin` | **Ampliació (+1 pt):** Gira la moneda contínuament sobre l'eix Y. **Ampliació (+1 pt):** Fa flotar la moneda amunt i avall suaument amb `Mathf.PingPong`. |

---

## 4. Controls

- **W, A, S, D** o **Fletxes de direcció**: Moviment de l'esfera del jugador pels eixos `Horizontal` (X) i `Vertical` (Z).
- **Botó Play (`MenuPrincipal.unity`)**: Carrega l'escena `Level1.unity`.

---

## 5. Captura de pantalla del projecte en Unity

![Level1 en Unity](Level1_Gameplay.png)

