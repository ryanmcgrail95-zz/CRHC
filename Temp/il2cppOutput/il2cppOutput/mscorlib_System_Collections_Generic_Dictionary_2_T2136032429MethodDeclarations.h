﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>
#include <assert.h>
#include <exception>

// System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.Color,System.Object,System.Object>
struct Transform_1_t2136032429;
// System.Object
struct Il2CppObject;
// System.IAsyncResult
struct IAsyncResult_t1999651008;
// System.AsyncCallback
struct AsyncCallback_t163412349;

#include "codegen/il2cpp-codegen.h"
#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_IntPtr2504060609.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"
#include "mscorlib_System_AsyncCallback163412349.h"

// System.Void System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.Color,System.Object,System.Object>::.ctor(System.Object,System.IntPtr)
extern "C"  void Transform_1__ctor_m2422625683_gshared (Transform_1_t2136032429 * __this, Il2CppObject * ___object0, IntPtr_t ___method1, const MethodInfo* method);
#define Transform_1__ctor_m2422625683(__this, ___object0, ___method1, method) ((  void (*) (Transform_1_t2136032429 *, Il2CppObject *, IntPtr_t, const MethodInfo*))Transform_1__ctor_m2422625683_gshared)(__this, ___object0, ___method1, method)
// TRet System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.Color,System.Object,System.Object>::Invoke(TKey,TValue)
extern "C"  Il2CppObject * Transform_1_Invoke_m311445671_gshared (Transform_1_t2136032429 * __this, Color_t2020392075  ___key0, Il2CppObject * ___value1, const MethodInfo* method);
#define Transform_1_Invoke_m311445671(__this, ___key0, ___value1, method) ((  Il2CppObject * (*) (Transform_1_t2136032429 *, Color_t2020392075 , Il2CppObject *, const MethodInfo*))Transform_1_Invoke_m311445671_gshared)(__this, ___key0, ___value1, method)
// System.IAsyncResult System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.Color,System.Object,System.Object>::BeginInvoke(TKey,TValue,System.AsyncCallback,System.Object)
extern "C"  Il2CppObject * Transform_1_BeginInvoke_m3813277530_gshared (Transform_1_t2136032429 * __this, Color_t2020392075  ___key0, Il2CppObject * ___value1, AsyncCallback_t163412349 * ___callback2, Il2CppObject * ___object3, const MethodInfo* method);
#define Transform_1_BeginInvoke_m3813277530(__this, ___key0, ___value1, ___callback2, ___object3, method) ((  Il2CppObject * (*) (Transform_1_t2136032429 *, Color_t2020392075 , Il2CppObject *, AsyncCallback_t163412349 *, Il2CppObject *, const MethodInfo*))Transform_1_BeginInvoke_m3813277530_gshared)(__this, ___key0, ___value1, ___callback2, ___object3, method)
// TRet System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.Color,System.Object,System.Object>::EndInvoke(System.IAsyncResult)
extern "C"  Il2CppObject * Transform_1_EndInvoke_m467056961_gshared (Transform_1_t2136032429 * __this, Il2CppObject * ___result0, const MethodInfo* method);
#define Transform_1_EndInvoke_m467056961(__this, ___result0, method) ((  Il2CppObject * (*) (Transform_1_t2136032429 *, Il2CppObject *, const MethodInfo*))Transform_1_EndInvoke_m467056961_gshared)(__this, ___result0, method)
