﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// System.Type
struct Type_t;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t2058570427;

#include "Newtonsoft_Json_Newtonsoft_Json_Serialization_JsonS795582376.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Newtonsoft.Json.Serialization.JsonSerializerInternalWriter
struct  JsonSerializerInternalWriter_t3234521618  : public JsonSerializerInternalBase_t795582376
{
public:
	// System.Type Newtonsoft.Json.Serialization.JsonSerializerInternalWriter::_rootType
	Type_t * ____rootType_5;
	// System.Int32 Newtonsoft.Json.Serialization.JsonSerializerInternalWriter::_rootLevel
	int32_t ____rootLevel_6;
	// System.Collections.Generic.List`1<System.Object> Newtonsoft.Json.Serialization.JsonSerializerInternalWriter::_serializeStack
	List_1_t2058570427 * ____serializeStack_7;

public:
	inline static int32_t get_offset_of__rootType_5() { return static_cast<int32_t>(offsetof(JsonSerializerInternalWriter_t3234521618, ____rootType_5)); }
	inline Type_t * get__rootType_5() const { return ____rootType_5; }
	inline Type_t ** get_address_of__rootType_5() { return &____rootType_5; }
	inline void set__rootType_5(Type_t * value)
	{
		____rootType_5 = value;
		Il2CppCodeGenWriteBarrier(&____rootType_5, value);
	}

	inline static int32_t get_offset_of__rootLevel_6() { return static_cast<int32_t>(offsetof(JsonSerializerInternalWriter_t3234521618, ____rootLevel_6)); }
	inline int32_t get__rootLevel_6() const { return ____rootLevel_6; }
	inline int32_t* get_address_of__rootLevel_6() { return &____rootLevel_6; }
	inline void set__rootLevel_6(int32_t value)
	{
		____rootLevel_6 = value;
	}

	inline static int32_t get_offset_of__serializeStack_7() { return static_cast<int32_t>(offsetof(JsonSerializerInternalWriter_t3234521618, ____serializeStack_7)); }
	inline List_1_t2058570427 * get__serializeStack_7() const { return ____serializeStack_7; }
	inline List_1_t2058570427 ** get_address_of__serializeStack_7() { return &____serializeStack_7; }
	inline void set__serializeStack_7(List_1_t2058570427 * value)
	{
		____serializeStack_7 = value;
		Il2CppCodeGenWriteBarrier(&____serializeStack_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
