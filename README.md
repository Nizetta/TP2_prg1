# Datos del alumno 
**Izetta Nicolas Denis** LU:461 DNI:44280726
> **Asignatura:** Programación de Videojuegos I 
> **Carrera:** Tecnicatura Universitaria en Diseño Integral de Videojuegos (TUDIVJ) — UNJu 
> **Trabajo Práctico N° 2:** 
>**Equipo Docente:** Mg. Ing. Ariel Alejandro Vega | Tecn. Kevin Alexis Roman Llampa 


# Proyecto de Videojuego Unity

Este proyecto es un prototipo de videojuego desarrollado con Unity 6000.5.7f1. La base del juego incluye movimiento del personaje, movientos de enemigos generado por ia, tienen vida, jugador y enemigo, usan ataques para eliminar el otro, tiene inicio, final y pause

## Descripción general

El juego está orientado a una experiencia simple de exploración: el jugador se desplaza por el escenario, escapar de los centinelas o enemigos.

## Características principales

- Movimiento del personaje en 3D
- Uso de Input System y componentes de Unity

## Controles

- WASD: movimiento del personaje
- Space / Jump: posible desplazamiento vertical o movimiento extra según la configuración de la escena
- Mouse: movimiento camara
- Click izquierdo: atacar
- P: pausar
- R: reaudar juego 

> Los controles pueden ajustarse según la escena final o la configuración del proyecto en Unity.

## Objetivo del juego

1. Moverse por el mapa.
2. Escapar de los centinelas.

## Estructura del proyecto

```text
Assets/
  Scenes/
  Scripts/
  Settings/
  Synty/
  TextMesh Pro/
Packages/
ProjectSettings/
README.md
```

Los scripts principales se encuentran en `Assets/Scripts` y contienen la lógica de:

- movimiento del jugador
- ataque
- enemigo ia
- game manager
- cámara
- sistema de vida
- menu principal

## Requisitos

- Unity Hub
- Unity 6000.5.7f1 o compatible
- Visual Studio o VS Code para edición de scripts