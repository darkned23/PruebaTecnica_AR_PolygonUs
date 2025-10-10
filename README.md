# 🦜 Proyecto de Realidad Aumentada - Prueba Técnica AR/VR  
**Autor:** Jhon Edwar González Arenas  
**Empresa:** Academy by PolygonUs  
**Tipo de prueba:** Experiencia de Realidad Aumentada (AR)  
**Motor de desarrollo:** Unity 6  

---

## 🧩 Descripción General

Este proyecto corresponde a la **primera parte** de la prueba técnica para el puesto de **profesor de AR y VR** en **Academy by PolygonUs**.  
Consiste en el desarrollo de una experiencia **básica de Realidad Aumentada (RA)** en Unity, cumpliendo con los requerimientos propuestos y añadiendo mejoras visuales e interactivas respecto a las instrucciones originales.

---

## 🕹️ Descripción de la Experiencia

La aplicación utiliza **reconocimiento de imagen (image tracking)** para detectar un **marcador** predefinido.  
Al escanearlo, se despliega un **modelo 3D de un ave barranquera (Momotus momota)** que realiza una animación de aleteo suave en estado *idle*.

Alrededor del ave aparecen **dos botones interactivos en UI anclada**, que permiten realizar las siguientes acciones:

1. **Botón "Volar":**  
   Ejecuta una animación de vuelo del ave. Al finalizar, retorna automáticamente al estado *idle*.

2. **Botón "Cantar":**  
   Reproduce un **audio real del canto** del ave barranquera.

Estas interacciones enriquecen la experiencia, aportando un componente educativo y demostrando la integración de animaciones y audio dentro de un entorno AR funcional.

---

## 🧠 Funcionalidades Implementadas

| Requerimiento Original | Implementación | Estado |
|-------------------------|----------------|---------|
| Rastreo de marcador/imágen | Uso de SDK de AR Foundation para detectar y seguir un marcador | ✅ Cumplido |
| Aparición de objeto 3D sobre el marcador | Se muestra un ave barranquera animada | ✅ Cumplido |
| UI anclada con botones interactivos | Dos botones con acciones (volar y cantar) | ✅ Cumplido |
| Cambiar color o mostrar mensaje | Sustituido por interacciones más completas (animación + audio) | 🔄 Modificado / Mejorado |

---

## 🛠️ Tecnologías Utilizadas

- **Unity 6.2(6000.2.6f2)**  
- **AR Foundation (SDK de AR)**  
- **C#**  
- **Android Build Target (ARCore compatible)**  
- **Animaciones y Audio Integrado en Unity**

---

## 📁 Estructura de Entrega

### Carpeta RA:
- `RA_Build.zip` → Build ejecutable del proyecto AR (APK).  
- `Marker_Image.jpg` → Imagen del marcador utilizado para el rastreo.  
- `Instrucciones_RA.txt` → Guía básica de ejecución.

### Repositorio:
Este repositorio contiene el **proyecto completo de Unity**, incluyendo:  
- Código fuente en C#  
- Configuración de escena y prefabs  
- Controladores de animación y audio  
- Scripts de interacción

---

## ▶️ Instrucciones de Ejecución

### 🔧 Requisitos Previos

- **Dispositivo Android** con cámara funcional.  
- **Versión mínima:** Android **7.0 (Nougat)** o superior.  
- **Compatibilidad AR:** El dispositivo debe ser **compatible con ARCore**.  
- **Espacio libre recomendado:** Al menos **200 MB**.  
- **Conexión a Internet:** No es obligatoria, pero se recomienda para la primera instalación.  

### 📲 Instalación del APK

1. Descargar y descomprimir el archivo `RA_Build.zip` dentro de la carpeta **RA**.  
2. Copiar el archivo `.apk` al dispositivo móvil (por cable USB, AirDrop, Drive, etc.).  
3. En el dispositivo Android:
   - Abrir **Configuración > Seguridad**.  
   - Activar la opción **“Permitir instalación de aplicaciones de orígenes desconocidos”** (puede variar según la versión de Android).  
4. Abrir el archivo `.apk` desde el explorador de archivos del dispositivo y seguir las instrucciones de instalación.  

### 🚀 Ejecución de la Aplicación

1. Abrir la aplicación instalada desde el menú de apps.  
2. Otorgar los permisos necesarios cuando sean solicitados (cámara y almacenamiento).  
3. Imprimir o visualizar la imagen del marcador (`Marker_Image.jpg`) en otro dispositivo o en papel.  
4. Apuntar la cámara del teléfono hacia el marcador.  
5. Al detectarse la imagen:
   - Se mostrará el **ave barranquera animada**.  
   - Presionar el botón **“Volar”** para reproducir la animación de vuelo.  
   - Presionar el botón **“Cantar”** para escuchar el canto del ave.  

> 💡 **Consejo:** Asegúrate de que el entorno esté bien iluminado y que el marcador esté completamente visible para una mejor detección AR.

---

## 🎯 Objetivo de la Prueba

Demostrar la capacidad para:
- Implementar funcionalidades de realidad aumentada en Unity.  
- Integrar elementos 3D animados y audio.  
- Diseñar interacciones simples y funcionales.  
- Mantener una estructura de código limpia y clara.  

---

## 📄 Consideraciones Finales

El proyecto cumple con todas las pautas indicadas en las **Instrucciones Generales** y los **Requerimientos de la Experiencia AR**, incorporando además mejoras audiovisuales y de interacción que elevan la calidad de la experiencia.

---

## 🔗 Enlaces

- **Repositorio del Proyecto (Código Fuente):** https://github.com/darkned23/PruebaTecnica_AR_PolygonUs  
- **Carpeta en la Nube (Builds y Archivos Extras):** https://drive.google.com/drive/folders/1M-JPpBiAo5BR-BZYGgK1ClF_lhMrV5sc
