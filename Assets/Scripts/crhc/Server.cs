﻿using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

public class Server : CrchFolder<Tour> {
    private string url;

    /*=======================================================**=======================================================*/
    /*=========================================== CONSTRUCTOR/DECONSTRUCTOR ==========================================*/
    /*=======================================================**=======================================================*/
    public Server(string url) : base(null, null) {
        this.url = url;
    }

    /*=======================================================**=======================================================*/
    /*============================================== ACCESSORS/MUTATORS ==============================================*/
    /*=======================================================**=======================================================*/
    public override string getUrl() {
        return url;
    }

    public override IMenu buildMenu() {
        throw new NotImplementedException();
    }
}