function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function"); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, writable: true, configurable: true } }); if (superClass) _setPrototypeOf(subClass, superClass); }

function _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }

function _createSuper(Derived) { var hasNativeReflectConstruct = _isNativeReflectConstruct(); return function _createSuperInternal() { var Super = _getPrototypeOf(Derived), result; if (hasNativeReflectConstruct) { var NewTarget = _getPrototypeOf(this).constructor; result = Reflect.construct(Super, arguments, NewTarget); } else { result = Super.apply(this, arguments); } return _possibleConstructorReturn(this, result); }; }

function _possibleConstructorReturn(self, call) { if (call && (typeof call === "object" || typeof call === "function")) { return call; } return _assertThisInitialized(self); }

function _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return self; }

function _isNativeReflectConstruct() { if (typeof Reflect === "undefined" || !Reflect.construct) return false; if (Reflect.construct.sham) return false; if (typeof Proxy === "function") return true; try { Date.prototype.toString.call(Reflect.construct(Date, [], function () {})); return true; } catch (e) { return false; } }

function _getPrototypeOf(o) { _getPrototypeOf = Object.setPrototypeOf ? Object.getPrototypeOf : function _getPrototypeOf(o) { return o.__proto__ || Object.getPrototypeOf(o); }; return _getPrototypeOf(o); }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"], {
  /***/
  "./$$_lazy_route_resource lazy recursive":
  /*!******************************************************!*\
    !*** ./$$_lazy_route_resource lazy namespace object ***!
    \******************************************************/

  /*! no static exports found */

  /***/
  function $$_lazy_route_resourceLazyRecursive(module, exports) {
    function webpackEmptyAsyncContext(req) {
      // Here Promise.resolve().then() is used instead of new Promise() to prevent
      // uncaught exception popping up in devtools
      return Promise.resolve().then(function () {
        var e = new Error("Cannot find module '" + req + "'");
        e.code = 'MODULE_NOT_FOUND';
        throw e;
      });
    }

    webpackEmptyAsyncContext.keys = function () {
      return [];
    };

    webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
    module.exports = webpackEmptyAsyncContext;
    webpackEmptyAsyncContext.id = "./$$_lazy_route_resource lazy recursive";
    /***/
  },

  /***/
  "./node_modules/moment/locale sync recursive ^\\.\\/.*$":
  /*!**************************************************!*\
    !*** ./node_modules/moment/locale sync ^\.\/.*$ ***!
    \**************************************************/

  /*! no static exports found */

  /***/
  function node_modulesMomentLocaleSyncRecursive$(module, exports, __webpack_require__) {
    var map = {
      "./af": "./node_modules/moment/locale/af.js",
      "./af.js": "./node_modules/moment/locale/af.js",
      "./ar": "./node_modules/moment/locale/ar.js",
      "./ar-dz": "./node_modules/moment/locale/ar-dz.js",
      "./ar-dz.js": "./node_modules/moment/locale/ar-dz.js",
      "./ar-kw": "./node_modules/moment/locale/ar-kw.js",
      "./ar-kw.js": "./node_modules/moment/locale/ar-kw.js",
      "./ar-ly": "./node_modules/moment/locale/ar-ly.js",
      "./ar-ly.js": "./node_modules/moment/locale/ar-ly.js",
      "./ar-ma": "./node_modules/moment/locale/ar-ma.js",
      "./ar-ma.js": "./node_modules/moment/locale/ar-ma.js",
      "./ar-sa": "./node_modules/moment/locale/ar-sa.js",
      "./ar-sa.js": "./node_modules/moment/locale/ar-sa.js",
      "./ar-tn": "./node_modules/moment/locale/ar-tn.js",
      "./ar-tn.js": "./node_modules/moment/locale/ar-tn.js",
      "./ar.js": "./node_modules/moment/locale/ar.js",
      "./az": "./node_modules/moment/locale/az.js",
      "./az.js": "./node_modules/moment/locale/az.js",
      "./be": "./node_modules/moment/locale/be.js",
      "./be.js": "./node_modules/moment/locale/be.js",
      "./bg": "./node_modules/moment/locale/bg.js",
      "./bg.js": "./node_modules/moment/locale/bg.js",
      "./bm": "./node_modules/moment/locale/bm.js",
      "./bm.js": "./node_modules/moment/locale/bm.js",
      "./bn": "./node_modules/moment/locale/bn.js",
      "./bn.js": "./node_modules/moment/locale/bn.js",
      "./bo": "./node_modules/moment/locale/bo.js",
      "./bo.js": "./node_modules/moment/locale/bo.js",
      "./br": "./node_modules/moment/locale/br.js",
      "./br.js": "./node_modules/moment/locale/br.js",
      "./bs": "./node_modules/moment/locale/bs.js",
      "./bs.js": "./node_modules/moment/locale/bs.js",
      "./ca": "./node_modules/moment/locale/ca.js",
      "./ca.js": "./node_modules/moment/locale/ca.js",
      "./cs": "./node_modules/moment/locale/cs.js",
      "./cs.js": "./node_modules/moment/locale/cs.js",
      "./cv": "./node_modules/moment/locale/cv.js",
      "./cv.js": "./node_modules/moment/locale/cv.js",
      "./cy": "./node_modules/moment/locale/cy.js",
      "./cy.js": "./node_modules/moment/locale/cy.js",
      "./da": "./node_modules/moment/locale/da.js",
      "./da.js": "./node_modules/moment/locale/da.js",
      "./de": "./node_modules/moment/locale/de.js",
      "./de-at": "./node_modules/moment/locale/de-at.js",
      "./de-at.js": "./node_modules/moment/locale/de-at.js",
      "./de-ch": "./node_modules/moment/locale/de-ch.js",
      "./de-ch.js": "./node_modules/moment/locale/de-ch.js",
      "./de.js": "./node_modules/moment/locale/de.js",
      "./dv": "./node_modules/moment/locale/dv.js",
      "./dv.js": "./node_modules/moment/locale/dv.js",
      "./el": "./node_modules/moment/locale/el.js",
      "./el.js": "./node_modules/moment/locale/el.js",
      "./en-au": "./node_modules/moment/locale/en-au.js",
      "./en-au.js": "./node_modules/moment/locale/en-au.js",
      "./en-ca": "./node_modules/moment/locale/en-ca.js",
      "./en-ca.js": "./node_modules/moment/locale/en-ca.js",
      "./en-gb": "./node_modules/moment/locale/en-gb.js",
      "./en-gb.js": "./node_modules/moment/locale/en-gb.js",
      "./en-ie": "./node_modules/moment/locale/en-ie.js",
      "./en-ie.js": "./node_modules/moment/locale/en-ie.js",
      "./en-il": "./node_modules/moment/locale/en-il.js",
      "./en-il.js": "./node_modules/moment/locale/en-il.js",
      "./en-in": "./node_modules/moment/locale/en-in.js",
      "./en-in.js": "./node_modules/moment/locale/en-in.js",
      "./en-nz": "./node_modules/moment/locale/en-nz.js",
      "./en-nz.js": "./node_modules/moment/locale/en-nz.js",
      "./en-sg": "./node_modules/moment/locale/en-sg.js",
      "./en-sg.js": "./node_modules/moment/locale/en-sg.js",
      "./eo": "./node_modules/moment/locale/eo.js",
      "./eo.js": "./node_modules/moment/locale/eo.js",
      "./es": "./node_modules/moment/locale/es.js",
      "./es-do": "./node_modules/moment/locale/es-do.js",
      "./es-do.js": "./node_modules/moment/locale/es-do.js",
      "./es-us": "./node_modules/moment/locale/es-us.js",
      "./es-us.js": "./node_modules/moment/locale/es-us.js",
      "./es.js": "./node_modules/moment/locale/es.js",
      "./et": "./node_modules/moment/locale/et.js",
      "./et.js": "./node_modules/moment/locale/et.js",
      "./eu": "./node_modules/moment/locale/eu.js",
      "./eu.js": "./node_modules/moment/locale/eu.js",
      "./fa": "./node_modules/moment/locale/fa.js",
      "./fa.js": "./node_modules/moment/locale/fa.js",
      "./fi": "./node_modules/moment/locale/fi.js",
      "./fi.js": "./node_modules/moment/locale/fi.js",
      "./fil": "./node_modules/moment/locale/fil.js",
      "./fil.js": "./node_modules/moment/locale/fil.js",
      "./fo": "./node_modules/moment/locale/fo.js",
      "./fo.js": "./node_modules/moment/locale/fo.js",
      "./fr": "./node_modules/moment/locale/fr.js",
      "./fr-ca": "./node_modules/moment/locale/fr-ca.js",
      "./fr-ca.js": "./node_modules/moment/locale/fr-ca.js",
      "./fr-ch": "./node_modules/moment/locale/fr-ch.js",
      "./fr-ch.js": "./node_modules/moment/locale/fr-ch.js",
      "./fr.js": "./node_modules/moment/locale/fr.js",
      "./fy": "./node_modules/moment/locale/fy.js",
      "./fy.js": "./node_modules/moment/locale/fy.js",
      "./ga": "./node_modules/moment/locale/ga.js",
      "./ga.js": "./node_modules/moment/locale/ga.js",
      "./gd": "./node_modules/moment/locale/gd.js",
      "./gd.js": "./node_modules/moment/locale/gd.js",
      "./gl": "./node_modules/moment/locale/gl.js",
      "./gl.js": "./node_modules/moment/locale/gl.js",
      "./gom-deva": "./node_modules/moment/locale/gom-deva.js",
      "./gom-deva.js": "./node_modules/moment/locale/gom-deva.js",
      "./gom-latn": "./node_modules/moment/locale/gom-latn.js",
      "./gom-latn.js": "./node_modules/moment/locale/gom-latn.js",
      "./gu": "./node_modules/moment/locale/gu.js",
      "./gu.js": "./node_modules/moment/locale/gu.js",
      "./he": "./node_modules/moment/locale/he.js",
      "./he.js": "./node_modules/moment/locale/he.js",
      "./hi": "./node_modules/moment/locale/hi.js",
      "./hi.js": "./node_modules/moment/locale/hi.js",
      "./hr": "./node_modules/moment/locale/hr.js",
      "./hr.js": "./node_modules/moment/locale/hr.js",
      "./hu": "./node_modules/moment/locale/hu.js",
      "./hu.js": "./node_modules/moment/locale/hu.js",
      "./hy-am": "./node_modules/moment/locale/hy-am.js",
      "./hy-am.js": "./node_modules/moment/locale/hy-am.js",
      "./id": "./node_modules/moment/locale/id.js",
      "./id.js": "./node_modules/moment/locale/id.js",
      "./is": "./node_modules/moment/locale/is.js",
      "./is.js": "./node_modules/moment/locale/is.js",
      "./it": "./node_modules/moment/locale/it.js",
      "./it-ch": "./node_modules/moment/locale/it-ch.js",
      "./it-ch.js": "./node_modules/moment/locale/it-ch.js",
      "./it.js": "./node_modules/moment/locale/it.js",
      "./ja": "./node_modules/moment/locale/ja.js",
      "./ja.js": "./node_modules/moment/locale/ja.js",
      "./jv": "./node_modules/moment/locale/jv.js",
      "./jv.js": "./node_modules/moment/locale/jv.js",
      "./ka": "./node_modules/moment/locale/ka.js",
      "./ka.js": "./node_modules/moment/locale/ka.js",
      "./kk": "./node_modules/moment/locale/kk.js",
      "./kk.js": "./node_modules/moment/locale/kk.js",
      "./km": "./node_modules/moment/locale/km.js",
      "./km.js": "./node_modules/moment/locale/km.js",
      "./kn": "./node_modules/moment/locale/kn.js",
      "./kn.js": "./node_modules/moment/locale/kn.js",
      "./ko": "./node_modules/moment/locale/ko.js",
      "./ko.js": "./node_modules/moment/locale/ko.js",
      "./ku": "./node_modules/moment/locale/ku.js",
      "./ku.js": "./node_modules/moment/locale/ku.js",
      "./ky": "./node_modules/moment/locale/ky.js",
      "./ky.js": "./node_modules/moment/locale/ky.js",
      "./lb": "./node_modules/moment/locale/lb.js",
      "./lb.js": "./node_modules/moment/locale/lb.js",
      "./lo": "./node_modules/moment/locale/lo.js",
      "./lo.js": "./node_modules/moment/locale/lo.js",
      "./lt": "./node_modules/moment/locale/lt.js",
      "./lt.js": "./node_modules/moment/locale/lt.js",
      "./lv": "./node_modules/moment/locale/lv.js",
      "./lv.js": "./node_modules/moment/locale/lv.js",
      "./me": "./node_modules/moment/locale/me.js",
      "./me.js": "./node_modules/moment/locale/me.js",
      "./mi": "./node_modules/moment/locale/mi.js",
      "./mi.js": "./node_modules/moment/locale/mi.js",
      "./mk": "./node_modules/moment/locale/mk.js",
      "./mk.js": "./node_modules/moment/locale/mk.js",
      "./ml": "./node_modules/moment/locale/ml.js",
      "./ml.js": "./node_modules/moment/locale/ml.js",
      "./mn": "./node_modules/moment/locale/mn.js",
      "./mn.js": "./node_modules/moment/locale/mn.js",
      "./mr": "./node_modules/moment/locale/mr.js",
      "./mr.js": "./node_modules/moment/locale/mr.js",
      "./ms": "./node_modules/moment/locale/ms.js",
      "./ms-my": "./node_modules/moment/locale/ms-my.js",
      "./ms-my.js": "./node_modules/moment/locale/ms-my.js",
      "./ms.js": "./node_modules/moment/locale/ms.js",
      "./mt": "./node_modules/moment/locale/mt.js",
      "./mt.js": "./node_modules/moment/locale/mt.js",
      "./my": "./node_modules/moment/locale/my.js",
      "./my.js": "./node_modules/moment/locale/my.js",
      "./nb": "./node_modules/moment/locale/nb.js",
      "./nb.js": "./node_modules/moment/locale/nb.js",
      "./ne": "./node_modules/moment/locale/ne.js",
      "./ne.js": "./node_modules/moment/locale/ne.js",
      "./nl": "./node_modules/moment/locale/nl.js",
      "./nl-be": "./node_modules/moment/locale/nl-be.js",
      "./nl-be.js": "./node_modules/moment/locale/nl-be.js",
      "./nl.js": "./node_modules/moment/locale/nl.js",
      "./nn": "./node_modules/moment/locale/nn.js",
      "./nn.js": "./node_modules/moment/locale/nn.js",
      "./oc-lnc": "./node_modules/moment/locale/oc-lnc.js",
      "./oc-lnc.js": "./node_modules/moment/locale/oc-lnc.js",
      "./pa-in": "./node_modules/moment/locale/pa-in.js",
      "./pa-in.js": "./node_modules/moment/locale/pa-in.js",
      "./pl": "./node_modules/moment/locale/pl.js",
      "./pl.js": "./node_modules/moment/locale/pl.js",
      "./pt": "./node_modules/moment/locale/pt.js",
      "./pt-br": "./node_modules/moment/locale/pt-br.js",
      "./pt-br.js": "./node_modules/moment/locale/pt-br.js",
      "./pt.js": "./node_modules/moment/locale/pt.js",
      "./ro": "./node_modules/moment/locale/ro.js",
      "./ro.js": "./node_modules/moment/locale/ro.js",
      "./ru": "./node_modules/moment/locale/ru.js",
      "./ru.js": "./node_modules/moment/locale/ru.js",
      "./sd": "./node_modules/moment/locale/sd.js",
      "./sd.js": "./node_modules/moment/locale/sd.js",
      "./se": "./node_modules/moment/locale/se.js",
      "./se.js": "./node_modules/moment/locale/se.js",
      "./si": "./node_modules/moment/locale/si.js",
      "./si.js": "./node_modules/moment/locale/si.js",
      "./sk": "./node_modules/moment/locale/sk.js",
      "./sk.js": "./node_modules/moment/locale/sk.js",
      "./sl": "./node_modules/moment/locale/sl.js",
      "./sl.js": "./node_modules/moment/locale/sl.js",
      "./sq": "./node_modules/moment/locale/sq.js",
      "./sq.js": "./node_modules/moment/locale/sq.js",
      "./sr": "./node_modules/moment/locale/sr.js",
      "./sr-cyrl": "./node_modules/moment/locale/sr-cyrl.js",
      "./sr-cyrl.js": "./node_modules/moment/locale/sr-cyrl.js",
      "./sr.js": "./node_modules/moment/locale/sr.js",
      "./ss": "./node_modules/moment/locale/ss.js",
      "./ss.js": "./node_modules/moment/locale/ss.js",
      "./sv": "./node_modules/moment/locale/sv.js",
      "./sv.js": "./node_modules/moment/locale/sv.js",
      "./sw": "./node_modules/moment/locale/sw.js",
      "./sw.js": "./node_modules/moment/locale/sw.js",
      "./ta": "./node_modules/moment/locale/ta.js",
      "./ta.js": "./node_modules/moment/locale/ta.js",
      "./te": "./node_modules/moment/locale/te.js",
      "./te.js": "./node_modules/moment/locale/te.js",
      "./tet": "./node_modules/moment/locale/tet.js",
      "./tet.js": "./node_modules/moment/locale/tet.js",
      "./tg": "./node_modules/moment/locale/tg.js",
      "./tg.js": "./node_modules/moment/locale/tg.js",
      "./th": "./node_modules/moment/locale/th.js",
      "./th.js": "./node_modules/moment/locale/th.js",
      "./tk": "./node_modules/moment/locale/tk.js",
      "./tk.js": "./node_modules/moment/locale/tk.js",
      "./tl-ph": "./node_modules/moment/locale/tl-ph.js",
      "./tl-ph.js": "./node_modules/moment/locale/tl-ph.js",
      "./tlh": "./node_modules/moment/locale/tlh.js",
      "./tlh.js": "./node_modules/moment/locale/tlh.js",
      "./tr": "./node_modules/moment/locale/tr.js",
      "./tr.js": "./node_modules/moment/locale/tr.js",
      "./tzl": "./node_modules/moment/locale/tzl.js",
      "./tzl.js": "./node_modules/moment/locale/tzl.js",
      "./tzm": "./node_modules/moment/locale/tzm.js",
      "./tzm-latn": "./node_modules/moment/locale/tzm-latn.js",
      "./tzm-latn.js": "./node_modules/moment/locale/tzm-latn.js",
      "./tzm.js": "./node_modules/moment/locale/tzm.js",
      "./ug-cn": "./node_modules/moment/locale/ug-cn.js",
      "./ug-cn.js": "./node_modules/moment/locale/ug-cn.js",
      "./uk": "./node_modules/moment/locale/uk.js",
      "./uk.js": "./node_modules/moment/locale/uk.js",
      "./ur": "./node_modules/moment/locale/ur.js",
      "./ur.js": "./node_modules/moment/locale/ur.js",
      "./uz": "./node_modules/moment/locale/uz.js",
      "./uz-latn": "./node_modules/moment/locale/uz-latn.js",
      "./uz-latn.js": "./node_modules/moment/locale/uz-latn.js",
      "./uz.js": "./node_modules/moment/locale/uz.js",
      "./vi": "./node_modules/moment/locale/vi.js",
      "./vi.js": "./node_modules/moment/locale/vi.js",
      "./x-pseudo": "./node_modules/moment/locale/x-pseudo.js",
      "./x-pseudo.js": "./node_modules/moment/locale/x-pseudo.js",
      "./yo": "./node_modules/moment/locale/yo.js",
      "./yo.js": "./node_modules/moment/locale/yo.js",
      "./zh-cn": "./node_modules/moment/locale/zh-cn.js",
      "./zh-cn.js": "./node_modules/moment/locale/zh-cn.js",
      "./zh-hk": "./node_modules/moment/locale/zh-hk.js",
      "./zh-hk.js": "./node_modules/moment/locale/zh-hk.js",
      "./zh-mo": "./node_modules/moment/locale/zh-mo.js",
      "./zh-mo.js": "./node_modules/moment/locale/zh-mo.js",
      "./zh-tw": "./node_modules/moment/locale/zh-tw.js",
      "./zh-tw.js": "./node_modules/moment/locale/zh-tw.js"
    };

    function webpackContext(req) {
      var id = webpackContextResolve(req);
      return __webpack_require__(id);
    }

    function webpackContextResolve(req) {
      if (!__webpack_require__.o(map, req)) {
        var e = new Error("Cannot find module '" + req + "'");
        e.code = 'MODULE_NOT_FOUND';
        throw e;
      }

      return map[req];
    }

    webpackContext.keys = function webpackContextKeys() {
      return Object.keys(map);
    };

    webpackContext.resolve = webpackContextResolve;
    module.exports = webpackContext;
    webpackContext.id = "./node_modules/moment/locale sync recursive ^\\.\\/.*$";
    /***/
  },

  /***/
  "./src/app/app-routing.module.ts":
  /*!***************************************!*\
    !*** ./src/app/app-routing.module.ts ***!
    \***************************************/

  /*! no static exports found */

  /***/
  function srcAppAppRoutingModuleTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var router_1 = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");

    var productPricingView_component_1 = __webpack_require__(
    /*! ./views/productPricingView.component */
    "./src/app/views/productPricingView.component.ts");

    var productSetupView_component_1 = __webpack_require__(
    /*! ./views/productSetupView.component */
    "./src/app/views/productSetupView.component.ts");

    var optionPricingView_component_1 = __webpack_require__(
    /*! ./views/optionPricingView.component */
    "./src/app/views/optionPricingView.component.ts");

    var productPackageView_Component_1 = __webpack_require__(
    /*! ./views/productPackageView.Component */
    "./src/app/views/productPackageView.Component.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");

    var routes = [{
      path: 'productSetup',
      component: productSetupView_component_1.ProductSetupViewComponent
    }, {
      path: 'productPricing',
      component: productPricingView_component_1.ProductPricingViewComponent
    }, {
      path: 'productPackaging',
      component: productPackageView_Component_1.ProductPackageViewComponent
    }, {
      path: 'optionPricing',
      component: optionPricingView_component_1.OptionPricingViewComponent
    }, {
      path: 'productPricing/:testParameter',
      component: productPricingView_component_1.ProductPricingViewComponent
    }, {
      path: '',
      redirectTo: '/productSetup',
      pathMatch: 'full'
    }];

    var AppRoutingModule = function AppRoutingModule() {
      _classCallCheck(this, AppRoutingModule);
    };

    exports.AppRoutingModule = AppRoutingModule;
    AppRoutingModule.??mod = i0.????defineNgModule({
      type: AppRoutingModule
    });
    AppRoutingModule.??inj = i0.????defineInjector({
      factory: function AppRoutingModule_Factory(t) {
        return new (t || AppRoutingModule)();
      },
      imports: [[router_1.RouterModule.forRoot(routes)], router_1.RouterModule]
    });

    (function () {
      (typeof ngJitMode === "undefined" || ngJitMode) && i0.????setNgModuleScope(AppRoutingModule, {
        imports: [i1.RouterModule],
        exports: [router_1.RouterModule]
      });
    })();
    /*@__PURE__*/


    (function () {
      i0.??setClassMetadata(AppRoutingModule, [{
        type: core_1.NgModule,
        args: [{
          imports: [router_1.RouterModule.forRoot(routes)],
          exports: [router_1.RouterModule]
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/app.component.ts":
  /*!**********************************!*\
    !*** ./src/app/app.component.ts ***!
    \**********************************/

  /*! no static exports found */

  /***/
  function srcAppAppComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! ../commonComponents/service/serviceLocator.service */
    "./src/commonComponents/service/serviceLocator.service.ts");

    var i2 = __webpack_require__(
    /*! primeng/toast */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-toast.js");

    var i3 = __webpack_require__(
    /*! primeng/menu */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-menu.js");

    var i4 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i5 = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");

    var AppComponent = /*#__PURE__*/function () {
      function AppComponent(locator) {
        _classCallCheck(this, AppComponent);

        this.locator = locator;
        this.title = 'angular-product-setup';
        var url = "https://localhost:44341"; //location.origin;

        this.locator.setUrl(url);
      }

      _createClass(AppComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.items = [{
            label: 'Definitions',
            routerLink: ['/productSetup']
          }, {
            label: 'Price Products',
            routerLink: ['/productPricing']
          }, {
            label: 'Price Options',
            routerLink: ['/optionPricing']
          }, {
            label: 'Package Product',
            routerLink: ['/productPackaging']
          }];
        }
      }]);

      return AppComponent;
    }();

    exports.AppComponent = AppComponent;

    AppComponent.??fac = function AppComponent_Factory(t) {
      return new (t || AppComponent)(i0.????directiveInject(i1.ServiceLocatorService));
    };

    AppComponent.??cmp = i0.????defineComponent({
      type: AppComponent,
      selectors: [["app-root"]],
      decls: 6,
      vars: 1,
      consts: [["popup", "popup", 3, "model"], ["menu", ""], ["type", "button", "pButton", "", "icon", "fa fa-list", "label", "Product Menu", 3, "click"]],
      template: function AppComponent_Template(rf, ctx) {
        if (rf & 1) {
          var _r1 = i0.????getCurrentView();

          i0.????element(0, "p-toast");
          i0.????element(1, "p-menu", 0, 1);
          i0.????elementStart(3, "button", 2);
          i0.????listener("click", function AppComponent_Template_button_click_3_listener($event) {
            i0.????restoreView(_r1);

            var _r0 = i0.????reference(2);

            return _r0.toggle($event);
          });
          i0.????elementEnd();
          i0.????element(4, "br");
          i0.????element(5, "router-outlet");
        }

        if (rf & 2) {
          i0.????advance(1);
          i0.????property("model", ctx.items);
        }
      },
      directives: [i2.Toast, i3.Menu, i4.ButtonDirective, i5.RouterOutlet],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwcC5jb21wb25lbnQuY3NzIn0= */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(AppComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'app-root',
          templateUrl: './app.component.html',
          styleUrls: ['./app.component.css']
        }]
      }], function () {
        return [{
          type: i1.ServiceLocatorService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/app.module.ts":
  /*!*******************************!*\
    !*** ./src/app/app.module.ts ***!
    \*******************************/

  /*! no static exports found */

  /***/
  function srcAppAppModuleTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var platform_browser_1 = __webpack_require__(
    /*! @angular/platform-browser */
    "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var common_1 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var animations_1 = __webpack_require__(
    /*! @angular/platform-browser/animations */
    "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/animations.js");

    var http_1 = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var forms_1 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js"); //Third party imports


    var tabview_1 = __webpack_require__(
    /*! primeng/tabview */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-tabview.js");

    var dropdown_1 = __webpack_require__(
    /*! primeng/dropdown */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dropdown.js");

    var fieldset_1 = __webpack_require__(
    /*! primeng/fieldset */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-fieldset.js");

    var button_1 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var checkbox_1 = __webpack_require__(
    /*! primeng/checkbox */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-checkbox.js");

    var table_1 = __webpack_require__(
    /*! primeng/table */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-table.js"); //import { SharedModule } from 'primeng/primeng';


    var dialog_1 = __webpack_require__(
    /*! primeng/dialog */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dialog.js"); //import { DataListModule } from 'primeng/primeng';


    var inputtext_1 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    var password_1 = __webpack_require__(
    /*! primeng/password */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-password.js");

    var toast_1 = __webpack_require__(
    /*! primeng/toast */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-toast.js");

    var picklist_1 = __webpack_require__(
    /*! primeng/picklist */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-picklist.js");

    var inputmask_1 = __webpack_require__(
    /*! primeng/inputmask */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputmask.js");

    var listbox_1 = __webpack_require__(
    /*! primeng/listbox */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-listbox.js");

    var menu_1 = __webpack_require__(
    /*! primeng/menu */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-menu.js");

    var calendar_1 = __webpack_require__(
    /*! primeng/calendar */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-calendar.js");

    var spinner_1 = __webpack_require__(
    /*! primeng/spinner */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-spinner.js");

    var api_1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var angular_fontawesome_1 = __webpack_require__(
    /*! @fortawesome/angular-fontawesome */
    "./node_modules/@fortawesome/angular-fontawesome/__ivy_ngcc__/fesm2015/angular-fontawesome.js");

    var app_routing_module_1 = __webpack_require__(
    /*! ./app-routing.module */
    "./src/app/app-routing.module.ts");

    var app_component_1 = __webpack_require__(
    /*! ./app.component */
    "./src/app/app.component.ts");

    var products_component_1 = __webpack_require__(
    /*! ./components/products/products.component */
    "./src/app/components/products/products.component.ts"); //product grid


    var productOptions_component_1 = __webpack_require__(
    /*! ./components/productOptions/productOptions.component */
    "./src/app/components/productOptions/productOptions.component.ts"); //product option grid


    var attributes_component_1 = __webpack_require__(
    /*! ./components/attributes/attributes.component */
    "./src/app/components/attributes/attributes.component.ts"); //product option grid


    var productSetup_component_1 = __webpack_require__(
    /*! ./components/productSetup/productSetup.component */
    "./src/app/components/productSetup/productSetup.component.ts"); //product configuration (setup)


    var baseProductPrices_component_1 = __webpack_require__(
    /*! ./components/baseProductPrices/baseProductPrices.component */
    "./src/app/components/baseProductPrices/baseProductPrices.component.ts"); //product prices grid


    var baseOptionPrices_component_1 = __webpack_require__(
    /*! ./components/baseOptionPrices/baseOptionPrices.component */
    "./src/app/components/baseOptionPrices/baseOptionPrices.component.ts"); //product option prices grid


    var price_component_1 = __webpack_require__(
    /*! ./components/price/price.component */
    "./src/app/components/price/price.component.ts"); //price detail


    var packagedProduct_component_1 = __webpack_require__(
    /*! ./components/packagedProduct/packagedProduct.component */
    "./src/app/components/packagedProduct/packagedProduct.component.ts");

    var product_component_1 = __webpack_require__(
    /*! ../commonComponents/components/product/product.component */
    "./src/commonComponents/components/product/product.component.ts"); //product detail


    var productOption_component_1 = __webpack_require__(
    /*! ../commonComponents/components/productOption/productOption.component */
    "./src/commonComponents/components/productOption/productOption.component.ts"); //product option detail


    var attribute_component_1 = __webpack_require__(
    /*! ../commonComponents/components/attribute/attribute.component */
    "./src/commonComponents/components/attribute/attribute.component.ts"); //product option detail


    var listEntry_component_1 = __webpack_require__(
    /*! ../commonComponents/components/listEntry/listEntry.component */
    "./src/commonComponents/components/listEntry/listEntry.component.ts");

    var propertyBag_component_1 = __webpack_require__(
    /*! ../commonComponents/components/propertyBag/propertyBag.component */
    "./src/commonComponents/components/propertyBag/propertyBag.component.ts"); //views


    var productPricingView_component_1 = __webpack_require__(
    /*! ./views/productPricingView.component */
    "./src/app/views/productPricingView.component.ts");

    var productSetupView_component_1 = __webpack_require__(
    /*! ./views/productSetupView.component */
    "./src/app/views/productSetupView.component.ts");

    var optionPricingView_component_1 = __webpack_require__(
    /*! ./views/optionPricingView.component */
    "./src/app/views/optionPricingView.component.ts");

    var productPackageView_Component_1 = __webpack_require__(
    /*! ./views/productPackageView.Component */
    "./src/app/views/productPackageView.Component.ts"); //application services


    var serviceLocator_service_1 = __webpack_require__(
    /*! ../commonComponents/service/serviceLocator.service */
    "./src/commonComponents/service/serviceLocator.service.ts"); //location of all services


    var product_service_1 = __webpack_require__(
    /*! ../commonComponents/service/product.service */
    "./src/commonComponents/service/product.service.ts");

    var productOption_service_1 = __webpack_require__(
    /*! ../commonComponents/service/productOption.service */
    "./src/commonComponents/service/productOption.service.ts");

    var attribute_service_1 = __webpack_require__(
    /*! ../commonComponents/service/attribute.service */
    "./src/commonComponents/service/attribute.service.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var AppModule = function AppModule() {
      _classCallCheck(this, AppModule);
    };

    exports.AppModule = AppModule;
    AppModule.??mod = i0.????defineNgModule({
      type: AppModule,
      bootstrap: [app_component_1.AppComponent]
    });
    AppModule.??inj = i0.????defineInjector({
      factory: function AppModule_Factory(t) {
        return new (t || AppModule)();
      },
      providers: [serviceLocator_service_1.ServiceLocatorService, api_1.MessageService, product_service_1.ProductService, productOption_service_1.ProductOptionService, attribute_service_1.AttributeService],
      imports: [[common_1.CommonModule, platform_browser_1.BrowserModule, animations_1.BrowserAnimationsModule, http_1.HttpClientModule, forms_1.FormsModule, tabview_1.TabViewModule, dropdown_1.DropdownModule, fieldset_1.FieldsetModule, button_1.ButtonModule, checkbox_1.CheckboxModule, table_1.TableModule, //SharedModule,
      dialog_1.DialogModule, inputtext_1.InputTextModule, password_1.PasswordModule, toast_1.ToastModule, picklist_1.PickListModule, inputmask_1.InputMaskModule, listbox_1.ListboxModule, menu_1.MenuModule, calendar_1.CalendarModule, spinner_1.SpinnerModule, angular_fontawesome_1.FontAwesomeModule, app_routing_module_1.AppRoutingModule]]
    });

    (function () {
      (typeof ngJitMode === "undefined" || ngJitMode) && i0.????setNgModuleScope(AppModule, {
        declarations: [app_component_1.AppComponent, productPricingView_component_1.ProductPricingViewComponent, productSetupView_component_1.ProductSetupViewComponent, optionPricingView_component_1.OptionPricingViewComponent, productPackageView_Component_1.ProductPackageViewComponent, products_component_1.ProductsComponent, product_component_1.ProductComponent, productOptions_component_1.ProductOptionsComponent, productOption_component_1.ProductOptionComponent, attributes_component_1.AttributesComponent, attribute_component_1.AttributeComponent, productSetup_component_1.ProductSetupComponent, listEntry_component_1.ListEntryComponent, baseProductPrices_component_1.BaseProductPricesComponent, baseOptionPrices_component_1.BaseOptionPricesComponent, price_component_1.PriceComponent, packagedProduct_component_1.PackagedProduct, propertyBag_component_1.PropertyBag],
        imports: [common_1.CommonModule, platform_browser_1.BrowserModule, animations_1.BrowserAnimationsModule, http_1.HttpClientModule, forms_1.FormsModule, tabview_1.TabViewModule, dropdown_1.DropdownModule, fieldset_1.FieldsetModule, button_1.ButtonModule, checkbox_1.CheckboxModule, table_1.TableModule, //SharedModule,
        dialog_1.DialogModule, inputtext_1.InputTextModule, password_1.PasswordModule, toast_1.ToastModule, picklist_1.PickListModule, inputmask_1.InputMaskModule, listbox_1.ListboxModule, menu_1.MenuModule, calendar_1.CalendarModule, spinner_1.SpinnerModule, angular_fontawesome_1.FontAwesomeModule, app_routing_module_1.AppRoutingModule]
      });
    })();
    /*@__PURE__*/


    (function () {
      i0.??setClassMetadata(AppModule, [{
        type: core_1.NgModule,
        args: [{
          declarations: [app_component_1.AppComponent, productPricingView_component_1.ProductPricingViewComponent, productSetupView_component_1.ProductSetupViewComponent, optionPricingView_component_1.OptionPricingViewComponent, productPackageView_Component_1.ProductPackageViewComponent, products_component_1.ProductsComponent, product_component_1.ProductComponent, productOptions_component_1.ProductOptionsComponent, productOption_component_1.ProductOptionComponent, attributes_component_1.AttributesComponent, attribute_component_1.AttributeComponent, productSetup_component_1.ProductSetupComponent, listEntry_component_1.ListEntryComponent, baseProductPrices_component_1.BaseProductPricesComponent, baseOptionPrices_component_1.BaseOptionPricesComponent, price_component_1.PriceComponent, packagedProduct_component_1.PackagedProduct, propertyBag_component_1.PropertyBag],
          providers: [serviceLocator_service_1.ServiceLocatorService, api_1.MessageService, product_service_1.ProductService, productOption_service_1.ProductOptionService, attribute_service_1.AttributeService],
          imports: [common_1.CommonModule, platform_browser_1.BrowserModule, animations_1.BrowserAnimationsModule, http_1.HttpClientModule, forms_1.FormsModule, tabview_1.TabViewModule, dropdown_1.DropdownModule, fieldset_1.FieldsetModule, button_1.ButtonModule, checkbox_1.CheckboxModule, table_1.TableModule, //SharedModule,
          dialog_1.DialogModule, inputtext_1.InputTextModule, password_1.PasswordModule, toast_1.ToastModule, picklist_1.PickListModule, inputmask_1.InputMaskModule, listbox_1.ListboxModule, menu_1.MenuModule, calendar_1.CalendarModule, spinner_1.SpinnerModule, angular_fontawesome_1.FontAwesomeModule, app_routing_module_1.AppRoutingModule],
          bootstrap: [app_component_1.AppComponent]
        }]
      }], null, null);
    })();
    /***/

  },

  /***/
  "./src/app/components/attributes/attributes.component.ts":
  /*!***************************************************************!*\
    !*** ./src/app/components/attributes/attributes.component.ts ***!
    \***************************************************************/

  /*! no static exports found */

  /***/
  function srcAppComponentsAttributesAttributesComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js"); //models


    var attributeModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/attributeModel */
    "./src/commonComponents/models/products/attributeModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../../commonComponents/service/attribute.service */
    "./src/commonComponents/service/attribute.service.ts");

    var i3 = __webpack_require__(
    /*! primeng/table */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-table.js");

    var i4 = __webpack_require__(
    /*! primeng/dialog */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dialog.js");

    var i5 = __webpack_require__(
    /*! ../../../commonComponents/components/attribute/attribute.component */
    "./src/commonComponents/components/attribute/attribute.component.ts");

    var i6 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i7 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function AttributesComponent_ng_template_2_Template(rf, ctx) {
      if (rf & 1) {
        var _r4 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "th");
        i0.????elementStart(2, "button", 9);
        i0.????listener("click", function AttributesComponent_ng_template_2_Template_button_click_2_listener() {
          i0.????restoreView(_r4);
          var ctx_r3 = i0.????nextContext();
          return ctx_r3.clickNewAttributeDialog();
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "th", 10);
        i0.????text(4, "Name");
        i0.????element(5, "p-sortIcon", 11);
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(6, "tr");
        i0.????element(7, "th");
        i0.????elementStart(8, "th");
        i0.????elementStart(9, "input", 12);
        i0.????listener("input", function AttributesComponent_ng_template_2_Template_input_input_9_listener($event) {
          i0.????restoreView(_r4);
          i0.????nextContext();

          var _r0 = i0.????reference(1);

          return _r0.filter($event.target.value, "name", "contains");
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }
    }

    function AttributesComponent_ng_template_3_Template(rf, ctx) {
      if (rf & 1) {
        var _r8 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "td");
        i0.????elementStart(2, "button", 13);
        i0.????listener("click", function AttributesComponent_ng_template_3_Template_button_click_2_listener() {
          i0.????restoreView(_r8);
          var attribute_r6 = ctx.$implicit;
          var ctx_r7 = i0.????nextContext();
          return ctx_r7.clickDetailAttributeDialog(attribute_r6);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "td");
        i0.????text(4);
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var attribute_r6 = ctx.$implicit;
        i0.????advance(4);
        i0.????textInterpolate(attribute_r6.name);
      }
    }

    var AttributesComponent = /*#__PURE__*/function () {
      function AttributesComponent(messageService, dataService) {
        _classCallCheck(this, AttributesComponent);

        this.messageService = messageService;
        this.dataService = dataService;
        this.attributeData = new Array();
      }

      _createClass(AttributesComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.loadAttributes();
        }
      }, {
        key: "loadAttributes",
        value: function loadAttributes() {
          var _this = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Loading Products'
          });
          this.dataService.getAttributes().subscribe(function (dataSet) {
            _this.attributeData = dataSet;

            _this.messageService.clear();
          }, function (ex) {
            return _this.handleError(ex);
          });
        }
      }, {
        key: "clickNewAttributeDialog",
        value: function clickNewAttributeDialog() {
          if (this.newAttribute == null) this.newAttribute = new attributeModel_1.AttributeModel();
          this.showNewAttributeDialog = true;
        }
      }, {
        key: "createNewAttributeDialogClick",
        value: function createNewAttributeDialogClick() {
          var _this2 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Saving Product'
          });
          var productOptionToUpload = this.newAttribute;
          this.dataService.setAttribute(productOptionToUpload).subscribe(function () {
            return _this2.loadAttributes();
          }, function (error) {
            return _this2.handleError(error);
          });
          this.showNewAttributeDialog = false;
        }
      }, {
        key: "clickDetailAttributeDialog",
        value: function clickDetailAttributeDialog(productOption) {
          this.selectedAttribute = productOption;
          this.showAttributeDetailDialog = true;
        }
      }, {
        key: "saveAttributeDetailDialogClick",
        value: function saveAttributeDetailDialogClick() {
          var _this3 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Saving Product'
          });
          var productOptionToUpload = this.selectedAttribute;
          this.dataService.setAttribute(productOptionToUpload).subscribe(function () {
            _this3.messageService.clear();
          }, function (error) {
            return _this3.handleError(error);
          });
          this.showAttributeDetailDialog = false;
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear();
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }]);

      return AttributesComponent;
    }();

    exports.AttributesComponent = AttributesComponent;

    AttributesComponent.??fac = function AttributesComponent_Factory(t) {
      return new (t || AttributesComponent)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.AttributeService));
    };

    AttributesComponent.??cmp = i0.????defineComponent({
      type: AttributesComponent,
      selectors: [["attributes"]],
      decls: 12,
      vars: 9,
      consts: [[3, "value", "rows", "paginator"], ["attributeTable", ""], ["pTemplate", "header"], ["pTemplate", "body"], ["header", "Create New Attribute", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], [3, "AttributeData"], ["type", "button", "pButton", "", "label", "Create Attribute", 3, "click"], ["header", "Attribute Details", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], ["type", "button", "pButton", "", "label", "Save Attribute", 3, "click"], ["type", "button", "pButton", "", "label", "Add", 3, "click"], ["pSortableColumn", "name"], ["field", "name"], ["pInputText", "", "type", "text", 3, "input"], ["type", "button", "pButton", "", "icon", "fa fa-binoculars", 3, "click"]],
      template: function AttributesComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "p-table", 0, 1);
          i0.????template(2, AttributesComponent_ng_template_2_Template, 10, 0, "ng-template", 2);
          i0.????template(3, AttributesComponent_ng_template_3_Template, 5, 1, "ng-template", 3);
          i0.????elementEnd();
          i0.????elementStart(4, "p-dialog", 4);
          i0.????listener("visibleChange", function AttributesComponent_Template_p_dialog_visibleChange_4_listener($event) {
            return ctx.showNewAttributeDialog = $event;
          });
          i0.????element(5, "attribute", 5);
          i0.????elementStart(6, "p-footer");
          i0.????elementStart(7, "button", 6);
          i0.????listener("click", function AttributesComponent_Template_button_click_7_listener() {
            return ctx.createNewAttributeDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(8, "p-dialog", 7);
          i0.????listener("visibleChange", function AttributesComponent_Template_p_dialog_visibleChange_8_listener($event) {
            return ctx.showAttributeDetailDialog = $event;
          });
          i0.????element(9, "attribute", 5);
          i0.????elementStart(10, "p-footer");
          i0.????elementStart(11, "button", 8);
          i0.????listener("click", function AttributesComponent_Template_button_click_11_listener() {
            return ctx.saveAttributeDetailDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("value", ctx.attributeData)("rows", 10)("paginator", true);
          i0.????advance(4);
          i0.????property("visible", ctx.showNewAttributeDialog)("closable", true);
          i0.????advance(1);
          i0.????property("AttributeData", ctx.newAttribute);
          i0.????advance(3);
          i0.????property("visible", ctx.showAttributeDetailDialog)("closable", true);
          i0.????advance(1);
          i0.????property("AttributeData", ctx.selectedAttribute);
        }
      },
      directives: [i3.Table, i1.PrimeTemplate, i4.Dialog, i5.AttributeComponent, i1.Footer, i6.ButtonDirective, i3.SortableColumn, i3.SortIcon, i7.InputText],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvYXR0cmlidXRlcy9hdHRyaWJ1dGVzLmNvbXBvbmVudC5jc3MifQ== */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(AttributesComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'attributes',
          templateUrl: './attributes.component.html',
          styleUrls: ['./attributes.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.AttributeService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/components/baseOptionPrices/baseOptionPrices.component.ts":
  /*!***************************************************************************!*\
    !*** ./src/app/components/baseOptionPrices/baseOptionPrices.component.ts ***!
    \***************************************************************************/

  /*! no static exports found */

  /***/
  function srcAppComponentsBaseOptionPricesBaseOptionPricesComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var priceModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/priceModel */
    "./src/commonComponents/models/products/priceModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../../commonComponents/service/productOption.service */
    "./src/commonComponents/service/productOption.service.ts");

    var i3 = __webpack_require__(
    /*! primeng/table */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-table.js");

    var i4 = __webpack_require__(
    /*! primeng/dialog */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dialog.js");

    var i5 = __webpack_require__(
    /*! ../price/price.component */
    "./src/app/components/price/price.component.ts");

    var i6 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i7 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function BaseOptionPricesComponent_ng_template_2_Template(rf, ctx) {
      if (rf & 1) {
        var _r4 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "th", 9);
        i0.????text(2, "Name");
        i0.????element(3, "p-sortIcon", 10);
        i0.????elementEnd();
        i0.????elementStart(4, "th");
        i0.????text(5, "Pricing");
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(6, "tr");
        i0.????elementStart(7, "th");
        i0.????elementStart(8, "input", 11);
        i0.????listener("input", function BaseOptionPricesComponent_ng_template_2_Template_input_input_8_listener($event) {
          i0.????restoreView(_r4);
          i0.????nextContext();

          var _r0 = i0.????reference(1);

          return _r0.filter($event.target.value, "option.name", "contains");
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(9, "th");
        i0.????text(10, "The price with a range of 12/31/9999 to 12/31/9999 is the default price.");
        i0.????elementEnd();
        i0.????elementEnd();
      }
    }

    function BaseOptionPricesComponent_ng_template_3_ng_template_5_Template(rf, ctx) {
      if (rf & 1) {
        var _r10 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "th");
        i0.????elementStart(2, "button", 13);
        i0.????listener("click", function BaseOptionPricesComponent_ng_template_3_ng_template_5_Template_button_click_2_listener() {
          i0.????restoreView(_r10);
          var productOptionPricing_r5 = i0.????nextContext().$implicit;
          var ctx_r8 = i0.????nextContext();
          return ctx_r8.clickNewProductPricing(productOptionPricing_r5);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "th");
        i0.????text(4, "Start");
        i0.????elementEnd();
        i0.????elementStart(5, "th");
        i0.????text(6, "End");
        i0.????elementEnd();
        i0.????elementEnd();
      }
    }

    function BaseOptionPricesComponent_ng_template_3_ng_template_6_Template(rf, ctx) {
      if (rf & 1) {
        var _r14 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "td");
        i0.????elementStart(2, "button", 14);
        i0.????listener("click", function BaseOptionPricesComponent_ng_template_3_ng_template_6_Template_button_click_2_listener() {
          i0.????restoreView(_r14);
          var price_r11 = ctx.$implicit;
          var productOptionPricing_r5 = i0.????nextContext().$implicit;
          var ctx_r12 = i0.????nextContext();
          return ctx_r12.clickEditProductPricing(productOptionPricing_r5.option, price_r11);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "td");
        i0.????text(4);
        i0.????elementEnd();
        i0.????elementStart(5, "td");
        i0.????text(6);
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var price_r11 = ctx.$implicit;
        i0.????advance(4);
        i0.????textInterpolate(price_r11.startFormatted);
        i0.????advance(2);
        i0.????textInterpolate(price_r11.endFormatted);
      }
    }

    function BaseOptionPricesComponent_ng_template_3_Template(rf, ctx) {
      if (rf & 1) {
        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "td");
        i0.????text(2);
        i0.????elementEnd();
        i0.????elementStart(3, "td");
        i0.????elementStart(4, "p-table", 12);
        i0.????template(5, BaseOptionPricesComponent_ng_template_3_ng_template_5_Template, 7, 0, "ng-template", 2);
        i0.????template(6, BaseOptionPricesComponent_ng_template_3_ng_template_6_Template, 7, 2, "ng-template", 3);
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var productOptionPricing_r5 = ctx.$implicit;
        i0.????advance(2);
        i0.????textInterpolate(productOptionPricing_r5.option.name);
        i0.????advance(2);
        i0.????property("value", productOptionPricing_r5.prices);
      }
    }

    var BaseOptionPricesComponent = /*#__PURE__*/function () {
      function BaseOptionPricesComponent(messageService, dataService) {
        _classCallCheck(this, BaseOptionPricesComponent);

        this.messageService = messageService;
        this.dataService = dataService;
      }

      _createClass(BaseOptionPricesComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.showNewOptionPricingDialog = false;
          this.loadProductOptions();
        }
      }, {
        key: "loadProductOptions",
        value: function loadProductOptions() {
          var _this4 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Loading Products'
          });
          this.dataService.getProductOptionsWithPrices().subscribe(function (dataSet) {
            _this4.productOptionData = dataSet;

            _this4.messageService.clear();
          }, function (ex) {
            return _this4.handleError(ex);
          });
        }
      }, {
        key: "clickNewProductPricing",
        value: function clickNewProductPricing(optionPricing) {
          this.selectedOptionObject = optionPricing.option;
          this.priceDialogObject = new priceModel_1.PriceModel(); //the constructor will set the dates to today

          this.priceDialogObject.startDateTime.setDate(this.priceDialogObject.startDateTime.getDate());
          this.priceDialogObject.endDateTime.setDate(this.priceDialogObject.startDateTime.getDate());
          this.priceDialogObject.formulaVariables = optionPricing.prices[0].formulaVariables; // an initial price had to been already created so there will always be at least one price

          this.showNewOptionPricingDialog = true;
        }
      }, {
        key: "clickEditProductPricing",
        value: function clickEditProductPricing(product, price) {
          this.selectedOptionObject = product;
          this.priceDialogObject = price;
          this.showEditOptionPricingDialog = true;
        }
      }, {
        key: "createNewProductOptionPriceDialogClick",
        value: function createNewProductOptionPriceDialogClick() {
          var _this5 = this;

          //lets not let any fluff like time get in the way of the date comparison
          this.priceDialogObject.startDateTime.setHours(0, 0, 0, 0);
          this.priceDialogObject.endDateTime.setHours(0, 0, 0, 0);

          if (this.priceDialogObject.startDateTime.getDate() > this.priceDialogObject.endDateTime.getDate()) {
            this.handleError('The start date can not be after the end date!');
          } else {
            this.dataService.setProductOptionPrice(this.selectedOptionObject, this.priceDialogObject).subscribe(function () {
              _this5.messageService.clear();

              _this5.loadProductOptions();

              _this5.showNewOptionPricingDialog = false;
            }, function (error) {
              return _this5.handleError(error);
            });
          }
        }
      }, {
        key: "saveProductOptionPriceDialogClick",
        value: function saveProductOptionPriceDialogClick() {
          var _this6 = this;

          //lets not let any fluff like time get in the way of the date comparison
          this.priceDialogObject.startDateTime.setHours(0, 0, 0, 0);
          this.priceDialogObject.endDateTime.setHours(0, 0, 0, 0);

          if (this.priceDialogObject.startDateTime > this.priceDialogObject.endDateTime) {
            this.handleError('The start date can not be after the end date!');
          } else {
            this.dataService.setProductOptionPrice(this.selectedOptionObject, this.priceDialogObject).subscribe(function () {
              _this6.messageService.clear();

              _this6.loadProductOptions();

              _this6.showEditOptionPricingDialog = false;
            }, function (error) {
              return _this6.handleError(error);
            });
          }
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear();
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }]);

      return BaseOptionPricesComponent;
    }();

    exports.BaseOptionPricesComponent = BaseOptionPricesComponent;

    BaseOptionPricesComponent.??fac = function BaseOptionPricesComponent_Factory(t) {
      return new (t || BaseOptionPricesComponent)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.ProductOptionService));
    };

    BaseOptionPricesComponent.??cmp = i0.????defineComponent({
      type: BaseOptionPricesComponent,
      selectors: [["baseOptionPrices"]],
      decls: 12,
      vars: 11,
      consts: [[3, "value", "rows", "paginator"], ["productOptionPricesTable", ""], ["pTemplate", "header"], ["pTemplate", "body"], ["header", "Create New Product Option Pricing", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], [3, "priceData", "showFormula"], ["type", "button", "pButton", "", "label", "Create Price", 3, "click"], ["header", "Product Option Pricing Details", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], ["type", "button", "pButton", "", "label", "Save Price", 3, "click"], ["pSortableColumn", "name"], ["field", "name"], ["pInputText", "", "type", "text", 3, "input"], [3, "value"], ["type", "button", "pButton", "", "label", "Add Pricing", 3, "click"], ["type", "button", "pButton", "", "icon", "fa fa-binoculars", 3, "click"]],
      template: function BaseOptionPricesComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "p-table", 0, 1);
          i0.????template(2, BaseOptionPricesComponent_ng_template_2_Template, 11, 0, "ng-template", 2);
          i0.????template(3, BaseOptionPricesComponent_ng_template_3_Template, 7, 2, "ng-template", 3);
          i0.????elementEnd();
          i0.????elementStart(4, "p-dialog", 4);
          i0.????listener("visibleChange", function BaseOptionPricesComponent_Template_p_dialog_visibleChange_4_listener($event) {
            return ctx.showNewOptionPricingDialog = $event;
          });
          i0.????element(5, "price", 5);
          i0.????elementStart(6, "p-footer");
          i0.????elementStart(7, "button", 6);
          i0.????listener("click", function BaseOptionPricesComponent_Template_button_click_7_listener() {
            return ctx.createNewProductOptionPriceDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(8, "p-dialog", 7);
          i0.????listener("visibleChange", function BaseOptionPricesComponent_Template_p_dialog_visibleChange_8_listener($event) {
            return ctx.showEditOptionPricingDialog = $event;
          });
          i0.????element(9, "price", 5);
          i0.????elementStart(10, "p-footer");
          i0.????elementStart(11, "button", 8);
          i0.????listener("click", function BaseOptionPricesComponent_Template_button_click_11_listener() {
            return ctx.saveProductOptionPriceDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("value", ctx.productOptionData)("rows", 10)("paginator", true);
          i0.????advance(4);
          i0.????property("visible", ctx.showNewOptionPricingDialog)("closable", true);
          i0.????advance(1);
          i0.????property("priceData", ctx.priceDialogObject)("showFormula", false);
          i0.????advance(3);
          i0.????property("visible", ctx.showEditOptionPricingDialog)("closable", true);
          i0.????advance(1);
          i0.????property("priceData", ctx.priceDialogObject)("showFormula", false);
        }
      },
      directives: [i3.Table, i1.PrimeTemplate, i4.Dialog, i5.PriceComponent, i1.Footer, i6.ButtonDirective, i3.SortableColumn, i3.SortIcon, i7.InputText],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvYmFzZU9wdGlvblByaWNlcy9iYXNlT3B0aW9uUHJpY2VzLmNvbXBvbmVudC5jc3MifQ== */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(BaseOptionPricesComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'baseOptionPrices',
          templateUrl: './baseOptionPrices.component.html',
          styleUrls: ['./baseOptionPrices.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.ProductOptionService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/components/baseProductPrices/baseProductPrices.component.ts":
  /*!*****************************************************************************!*\
    !*** ./src/app/components/baseProductPrices/baseProductPrices.component.ts ***!
    \*****************************************************************************/

  /*! no static exports found */

  /***/
  function srcAppComponentsBaseProductPricesBaseProductPricesComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var priceModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/priceModel */
    "./src/commonComponents/models/products/priceModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../../commonComponents/service/product.service */
    "./src/commonComponents/service/product.service.ts");

    var i3 = __webpack_require__(
    /*! primeng/table */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-table.js");

    var i4 = __webpack_require__(
    /*! primeng/dialog */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dialog.js");

    var i5 = __webpack_require__(
    /*! ../price/price.component */
    "./src/app/components/price/price.component.ts");

    var i6 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i7 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function BaseProductPricesComponent_ng_template_2_Template(rf, ctx) {
      if (rf & 1) {
        var _r4 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "th", 9);
        i0.????text(2, "Name");
        i0.????element(3, "p-sortIcon", 10);
        i0.????elementEnd();
        i0.????elementStart(4, "th");
        i0.????text(5, "Pricing");
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(6, "tr");
        i0.????elementStart(7, "th");
        i0.????elementStart(8, "input", 11);
        i0.????listener("input", function BaseProductPricesComponent_ng_template_2_Template_input_input_8_listener($event) {
          i0.????restoreView(_r4);
          i0.????nextContext();

          var _r0 = i0.????reference(1);

          return _r0.filter($event.target.value, "product.name", "contains");
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(9, "th");
        i0.????text(10, "The price with a range of 12/31/9999 to 12/31/9999 is the default price.");
        i0.????elementEnd();
        i0.????elementEnd();
      }
    }

    function BaseProductPricesComponent_ng_template_3_ng_template_5_Template(rf, ctx) {
      if (rf & 1) {
        var _r10 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "th");
        i0.????elementStart(2, "button", 13);
        i0.????listener("click", function BaseProductPricesComponent_ng_template_3_ng_template_5_Template_button_click_2_listener() {
          i0.????restoreView(_r10);
          var productPricing_r5 = i0.????nextContext().$implicit;
          var ctx_r8 = i0.????nextContext();
          return ctx_r8.clickNewProductPricing(productPricing_r5);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "th");
        i0.????text(4, "Start");
        i0.????elementEnd();
        i0.????elementStart(5, "th");
        i0.????text(6, "End");
        i0.????elementEnd();
        i0.????elementStart(7, "th");
        i0.????text(8, "Price Is Formula Based");
        i0.????elementEnd();
        i0.????elementEnd();
      }
    }

    function BaseProductPricesComponent_ng_template_3_ng_template_6_Template(rf, ctx) {
      if (rf & 1) {
        var _r14 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "td");
        i0.????elementStart(2, "button", 14);
        i0.????listener("click", function BaseProductPricesComponent_ng_template_3_ng_template_6_Template_button_click_2_listener() {
          i0.????restoreView(_r14);
          var price_r11 = ctx.$implicit;
          var productPricing_r5 = i0.????nextContext().$implicit;
          var ctx_r12 = i0.????nextContext();
          return ctx_r12.clickEditProductPricing(productPricing_r5.product, price_r11);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "td");
        i0.????text(4);
        i0.????elementEnd();
        i0.????elementStart(5, "td");
        i0.????text(6);
        i0.????elementEnd();
        i0.????elementStart(7, "td");
        i0.????text(8);
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var price_r11 = ctx.$implicit;
        i0.????advance(4);
        i0.????textInterpolate(price_r11.startFormatted);
        i0.????advance(2);
        i0.????textInterpolate(price_r11.endFormatted);
        i0.????advance(2);
        i0.????textInterpolate(price_r11.hasFormula);
      }
    }

    function BaseProductPricesComponent_ng_template_3_Template(rf, ctx) {
      if (rf & 1) {
        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "td");
        i0.????text(2);
        i0.????elementEnd();
        i0.????elementStart(3, "td");
        i0.????elementStart(4, "p-table", 12);
        i0.????template(5, BaseProductPricesComponent_ng_template_3_ng_template_5_Template, 9, 0, "ng-template", 2);
        i0.????template(6, BaseProductPricesComponent_ng_template_3_ng_template_6_Template, 9, 3, "ng-template", 3);
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var productPricing_r5 = ctx.$implicit;
        i0.????advance(2);
        i0.????textInterpolate(productPricing_r5.product.name);
        i0.????advance(2);
        i0.????property("value", productPricing_r5.prices);
      }
    }

    var BaseProductPricesComponent = /*#__PURE__*/function () {
      function BaseProductPricesComponent(messageService, dataService) {
        _classCallCheck(this, BaseProductPricesComponent);

        this.messageService = messageService;
        this.dataService = dataService;
      }

      _createClass(BaseProductPricesComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.showNewProductPricingDialog = false;
          this.loadProducts();
        }
      }, {
        key: "loadProducts",
        value: function loadProducts() {
          var _this7 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Loading Products'
          });
          this.dataService.getProductsWithPrices().subscribe(function (dataSet) {
            _this7.productData = dataSet;

            _this7.messageService.clear();
          }, function (ex) {
            return _this7.handleError(ex);
          });
        }
      }, {
        key: "clickNewProductPricing",
        value: function clickNewProductPricing(productPrice) {
          this.selectedProductObject = productPrice.product;
          this.priceDialogObject = new priceModel_1.PriceModel(); //the constructor will set the dates to today

          this.priceDialogObject.startDateTime.setDate(this.priceDialogObject.startDateTime.getDate());
          this.priceDialogObject.endDateTime.setDate(this.priceDialogObject.startDateTime.getDate());
          this.priceDialogObject.formulaVariables = productPrice.prices[0].formulaVariables; // an initial price had to been already created so there will always be at least one price

          this.showNewProductPricingDialog = true;
        }
      }, {
        key: "clickEditProductPricing",
        value: function clickEditProductPricing(product, price) {
          this.selectedProductObject = product;
          this.priceDialogObject = price;
          this.showEditProductPricingDialog = true;
        }
      }, {
        key: "createNewProductPriceDialogClick",
        value: function createNewProductPriceDialogClick() {
          var _this8 = this;

          //lets not let any fluff like time get in the way of the date comparison
          this.priceDialogObject.startDateTime.setHours(0, 0, 0, 0);
          this.priceDialogObject.endDateTime.setHours(0, 0, 0, 0);

          if (this.priceDialogObject.startDateTime > this.priceDialogObject.endDateTime) {
            this.handleError('The start date can not be after the end date!');
          } else {
            this.dataService.setProductPrice(this.selectedProductObject, this.priceDialogObject).subscribe(function () {
              _this8.messageService.clear();

              _this8.loadProducts();

              _this8.showNewProductPricingDialog = false;
            }, function (error) {
              return _this8.handleError(error);
            });
          }
        }
      }, {
        key: "saveProductPriceDialogClick",
        value: function saveProductPriceDialogClick() {
          var _this9 = this;

          //lets not let any fluff like time get in the way of the date comparison
          this.priceDialogObject.startDateTime.setHours(0, 0, 0, 0);
          this.priceDialogObject.endDateTime.setHours(0, 0, 0, 0);

          if (this.priceDialogObject.startDateTime > this.priceDialogObject.endDateTime) {
            this.handleError('The start date can not be after the end date!');
          } else {
            this.dataService.setProductPrice(this.selectedProductObject, this.priceDialogObject).subscribe(function () {
              _this9.messageService.clear();

              _this9.loadProducts();

              _this9.showEditProductPricingDialog = false;
            }, function (error) {
              return _this9.handleError(error);
            });
          }
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear();
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }]);

      return BaseProductPricesComponent;
    }();

    exports.BaseProductPricesComponent = BaseProductPricesComponent;

    BaseProductPricesComponent.??fac = function BaseProductPricesComponent_Factory(t) {
      return new (t || BaseProductPricesComponent)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.ProductService));
    };

    BaseProductPricesComponent.??cmp = i0.????defineComponent({
      type: BaseProductPricesComponent,
      selectors: [["baseProductPrices"]],
      decls: 12,
      vars: 9,
      consts: [[3, "value", "rows", "paginator"], ["productPricesTable", ""], ["pTemplate", "header"], ["pTemplate", "body"], ["header", "Create New Product Pricing", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], [3, "priceData"], ["type", "button", "pButton", "", "label", "Create Price", 3, "click"], ["header", "Product Pricing Details", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], ["type", "button", "pButton", "", "label", "Save Price", 3, "click"], ["pSortableColumn", "name"], ["field", "name"], ["pInputText", "", "type", "text", 3, "input"], [3, "value"], ["type", "button", "pButton", "", "label", "Add Pricing", 3, "click"], ["type", "button", "pButton", "", "icon", "fa fa-binoculars", 3, "click"]],
      template: function BaseProductPricesComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "p-table", 0, 1);
          i0.????template(2, BaseProductPricesComponent_ng_template_2_Template, 11, 0, "ng-template", 2);
          i0.????template(3, BaseProductPricesComponent_ng_template_3_Template, 7, 2, "ng-template", 3);
          i0.????elementEnd();
          i0.????elementStart(4, "p-dialog", 4);
          i0.????listener("visibleChange", function BaseProductPricesComponent_Template_p_dialog_visibleChange_4_listener($event) {
            return ctx.showNewProductPricingDialog = $event;
          });
          i0.????element(5, "price", 5);
          i0.????elementStart(6, "p-footer");
          i0.????elementStart(7, "button", 6);
          i0.????listener("click", function BaseProductPricesComponent_Template_button_click_7_listener() {
            return ctx.createNewProductPriceDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(8, "p-dialog", 7);
          i0.????listener("visibleChange", function BaseProductPricesComponent_Template_p_dialog_visibleChange_8_listener($event) {
            return ctx.showEditProductPricingDialog = $event;
          });
          i0.????element(9, "price", 5);
          i0.????elementStart(10, "p-footer");
          i0.????elementStart(11, "button", 8);
          i0.????listener("click", function BaseProductPricesComponent_Template_button_click_11_listener() {
            return ctx.saveProductPriceDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("value", ctx.productData)("rows", 10)("paginator", true);
          i0.????advance(4);
          i0.????property("visible", ctx.showNewProductPricingDialog)("closable", true);
          i0.????advance(1);
          i0.????property("priceData", ctx.priceDialogObject);
          i0.????advance(3);
          i0.????property("visible", ctx.showEditProductPricingDialog)("closable", true);
          i0.????advance(1);
          i0.????property("priceData", ctx.priceDialogObject);
        }
      },
      directives: [i3.Table, i1.PrimeTemplate, i4.Dialog, i5.PriceComponent, i1.Footer, i6.ButtonDirective, i3.SortableColumn, i3.SortIcon, i7.InputText],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvYmFzZVByb2R1Y3RQcmljZXMvYmFzZVByb2R1Y3RQcmljZXMuY29tcG9uZW50LmNzcyJ9 */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(BaseProductPricesComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'baseProductPrices',
          templateUrl: './baseProductPrices.component.html',
          styleUrls: ['./baseProductPrices.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.ProductService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/components/packagedProduct/packagedProduct.component.ts":
  /*!*************************************************************************!*\
    !*** ./src/app/components/packagedProduct/packagedProduct.component.ts ***!
    \*************************************************************************/

  /*! no static exports found */

  /***/
  function srcAppComponentsPackagedProductPackagedProductComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var packagedProductDetailModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/packagedProductDetailModel */
    "./src/commonComponents/models/products/packagedProductDetailModel.ts");

    var packagedProductOptionModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/packagedProductOptionModel */
    "./src/commonComponents/models/products/packagedProductOptionModel.ts");

    var packagedProductOptionDetailModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/packagedProductOptionDetailModel */
    "./src/commonComponents/models/products/packagedProductOptionDetailModel.ts");

    var productDropDown_1 = __webpack_require__(
    /*! ../../models/productDropDown */
    "./src/app/models/productDropDown.ts");

    var propertyModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/propertyBag/propertyModel */
    "./src/commonComponents/models/propertyBag/propertyModel.ts");

    var possibleValueModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/propertyBag/possibleValueModel */
    "./src/commonComponents/models/propertyBag/possibleValueModel.ts");

    var productOptionDropDown_1 = __webpack_require__(
    /*! ../../models/productOptionDropDown */
    "./src/app/models/productOptionDropDown.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../../commonComponents/service/product.service */
    "./src/commonComponents/service/product.service.ts");

    var i3 = __webpack_require__(
    /*! ../../../commonComponents/service/productOption.service */
    "./src/commonComponents/service/productOption.service.ts");

    var i4 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var i5 = __webpack_require__(
    /*! primeng/tabview */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-tabview.js");

    var i6 = __webpack_require__(
    /*! primeng/dropdown */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dropdown.js");

    var i7 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i8 = __webpack_require__(
    /*! primeng/spinner */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-spinner.js");

    var i9 = __webpack_require__(
    /*! primeng/picklist */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-picklist.js");

    var i10 = __webpack_require__(
    /*! ../../../commonComponents/components/propertyBag/propertyBag.component */
    "./src/commonComponents/components/propertyBag/propertyBag.component.ts");

    function PackagedProduct_div_0_Template(rf, ctx) {
      if (rf & 1) {
        i0.????elementStart(0, "div");
        i0.????text(1);
        i0.????element(2, "br");
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r0 = i0.????nextContext();
        i0.????advance(1);
        i0.????textInterpolate2(" ", (ctx_r0.selectedProduct == null ? null : ctx_r0.selectedProduct.product == null ? null : ctx_r0.selectedProduct.product.name) ? ctx_r0.selectedProduct == null ? null : ctx_r0.selectedProduct.product == null ? null : ctx_r0.selectedProduct.product.name : "no product selected", ": ", (ctx_r0.selectedProduct == null ? null : ctx_r0.selectedProduct.product == null ? null : ctx_r0.selectedProduct.product.description) ? ctx_r0.selectedProduct == null ? null : ctx_r0.selectedProduct.product == null ? null : ctx_r0.selectedProduct.product.description : "", " ");
      }
    }

    function PackagedProduct_div_3_Template(rf, ctx) {
      if (rf & 1) {
        var _r8 = i0.????getCurrentView();

        i0.????elementStart(0, "div", 9);
        i0.????text(1, " Product to Package");
        i0.????element(2, "br");
        i0.????elementStart(3, "p-dropdown", 10);
        i0.????listener("ngModelChange", function PackagedProduct_div_3_Template_p_dropdown_ngModelChange_3_listener($event) {
          i0.????restoreView(_r8);
          var ctx_r7 = i0.????nextContext();
          return ctx_r7.selectedProduct = $event;
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r1 = i0.????nextContext();
        i0.????advance(3);
        i0.????property("options", ctx_r1.productList)("ngModel", ctx_r1.selectedProduct)("styleClass", "dropDownCol");
      }
    }

    function PackagedProduct_div_4_Template(rf, ctx) {
      if (rf & 1) {
        var _r10 = i0.????getCurrentView();

        i0.????elementStart(0, "div", 9);
        i0.????text(1, " Marketing lingo");
        i0.????element(2, "br");
        i0.????elementStart(3, "textarea", 11);
        i0.????listener("ngModelChange", function PackagedProduct_div_4_Template_textarea_ngModelChange_3_listener($event) {
          i0.????restoreView(_r10);
          var ctx_r9 = i0.????nextContext();
          return ctx_r9.incomingPackagedProduct.description = $event;
        });
        i0.????elementEnd();
        i0.????element(4, "br");
        i0.????text(5, " Number of products in package");
        i0.????element(6, "br");
        i0.????elementStart(7, "p-spinner", 12);
        i0.????listener("ngModelChange", function PackagedProduct_div_4_Template_p_spinner_ngModelChange_7_listener($event) {
          i0.????restoreView(_r10);
          var ctx_r11 = i0.????nextContext();
          return ctx_r11.incomingPackagedProduct.quantity = $event;
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r2 = i0.????nextContext();
        i0.????advance(3);
        i0.????property("rows", 5)("cols", 30)("ngModel", ctx_r2.incomingPackagedProduct.description);
        i0.????advance(4);
        i0.????property("ngModel", ctx_r2.incomingPackagedProduct.quantity)("min", 1)("step", 1);
      }
    }

    function PackagedProduct_div_6_ng_template_2_Template(rf, ctx) {
      if (rf & 1) {
        i0.????text(0);
      }

      if (rf & 2) {
        var option_r13 = ctx.$implicit;
        i0.????textInterpolate1(" ", option_r13.name, " ");
      }
    }

    function PackagedProduct_div_6_Template(rf, ctx) {
      if (rf & 1) {
        i0.????elementStart(0, "div", 9);
        i0.????elementStart(1, "p-pickList", 13);
        i0.????template(2, PackagedProduct_div_6_ng_template_2_Template, 1, 1, "ng-template", 14);
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r3 = i0.????nextContext();
        i0.????advance(1);
        i0.????property("sourceHeader", ctx_r3.avaiableOptionHeader)("source", ctx_r3.possibleProductOptions)("targetHeader", ctx_r3.selectedOptionHeader)("target", ctx_r3.selectedProductOptions)("showSourceControls", false)("showTargetControls", false);
      }
    }

    function PackagedProduct_div_8_Template(rf, ctx) {
      if (rf & 1) {
        var _r15 = i0.????getCurrentView();

        i0.????elementStart(0, "div");
        i0.????text(1, " Product Option ");
        i0.????elementStart(2, "p-dropdown", 15);
        i0.????listener("ngModelChange", function PackagedProduct_div_8_Template_p_dropdown_ngModelChange_2_listener($event) {
          i0.????restoreView(_r15);
          var ctx_r14 = i0.????nextContext();
          return ctx_r14.selectedProductOption = $event;
        })("onChange", function PackagedProduct_div_8_Template_p_dropdown_onChange_2_listener($event) {
          i0.????restoreView(_r15);
          var ctx_r16 = i0.????nextContext();
          return ctx_r16.handleProductOptionDropDownForOptionsDetailsTabChange($event);
        });
        i0.????elementEnd();
        i0.????element(3, "br");
        i0.????text(4, " Marketing lingo");
        i0.????element(5, "br");
        i0.????elementStart(6, "textarea", 11);
        i0.????listener("ngModelChange", function PackagedProduct_div_8_Template_textarea_ngModelChange_6_listener($event) {
          i0.????restoreView(_r15);
          var ctx_r17 = i0.????nextContext();
          return ctx_r17.productOptionMarketingLingo = $event;
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r4 = i0.????nextContext();
        i0.????advance(2);
        i0.????property("options", ctx_r4.selectedProductOptionsList)("ngModel", ctx_r4.selectedProductOption)("styleClass", "dropDownCol");
        i0.????advance(4);
        i0.????property("rows", 5)("cols", 30)("ngModel", ctx_r4.productOptionMarketingLingo);
      }
    }

    function PackagedProduct_div_10_Template(rf, ctx) {
      if (rf & 1) {
        var _r19 = i0.????getCurrentView();

        i0.????elementStart(0, "div", 9);
        i0.????elementStart(1, "propertyBag", 16);
        i0.????listener("ngModelChange", function PackagedProduct_div_10_Template_propertyBag_ngModelChange_1_listener($event) {
          i0.????restoreView(_r19);
          var ctx_r18 = i0.????nextContext();
          return ctx_r18.productAttributes = $event;
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r5 = i0.????nextContext();
        i0.????advance(1);
        i0.????property("ngModel", ctx_r5.productAttributes);
      }
    }

    function PackagedProduct_div_12_Template(rf, ctx) {
      if (rf & 1) {
        var _r21 = i0.????getCurrentView();

        i0.????elementStart(0, "div", 9);
        i0.????text(1, " Product Option to set Attributes for");
        i0.????element(2, "br");
        i0.????elementStart(3, "p-dropdown", 15);
        i0.????listener("ngModelChange", function PackagedProduct_div_12_Template_p_dropdown_ngModelChange_3_listener($event) {
          i0.????restoreView(_r21);
          var ctx_r20 = i0.????nextContext();
          return ctx_r20.selectedProductOption = $event;
        })("onChange", function PackagedProduct_div_12_Template_p_dropdown_onChange_3_listener($event) {
          i0.????restoreView(_r21);
          var ctx_r22 = i0.????nextContext();
          return ctx_r22.handleProductOptionDropDownForOptionAttributesTabChange($event);
        });
        i0.????elementEnd();
        i0.????elementStart(4, "propertyBag", 16);
        i0.????listener("ngModelChange", function PackagedProduct_div_12_Template_propertyBag_ngModelChange_4_listener($event) {
          i0.????restoreView(_r21);
          var ctx_r23 = i0.????nextContext();
          return ctx_r23.productOptionAttributes = $event;
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r6 = i0.????nextContext();
        i0.????advance(3);
        i0.????property("options", ctx_r6.selectedProductOptionsList)("ngModel", ctx_r6.selectedProductOption)("styleClass", "dropDownCol");
        i0.????advance(1);
        i0.????property("ngModel", ctx_r6.productOptionAttributes);
      }
    }

    var PackagedProduct = /*#__PURE__*/function () {
      function PackagedProduct(messageService, productService, productOptionService) {
        _classCallCheck(this, PackagedProduct);

        this.messageService = messageService;
        this.productService = productService;
        this.productOptionService = productOptionService;
        this.tabChanged = new core_1.EventEmitter(); //tab control

        this.tabIndex = 0;
        this.oldTabIndex = 0;
        this.selectedProduct = null;
        this.validProducts = false;
        this.avaiableOptionHeader = "Avaiable Options";
        this.selectedOptionHeader = "Selected Options";
        this.productOptionMarketingLingo = "";
      } //vars


      _createClass(PackagedProduct, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.loadProductList();
        }
      }, {
        key: "loadProductList",
        value: function loadProductList() {
          var _this10 = this;

          this.possibleProductOptions = new Array();
          this.selectedProductOptions = new Array();
          this.productList = new Array();
          this.productService.getProductsWithPrices().subscribe(function (products) {
            _this10.validProducts = products.length > 0;
            products.forEach(function (pricedProduct) {
              var tempProduct = new productDropDown_1.ProductDropDown();
              tempProduct.label = pricedProduct.product.name;
              tempProduct.value = pricedProduct;

              _this10.productList.push(tempProduct);
            });
          }, function (error) {
            return _this10.handleError(error);
          });
        }
      }, {
        key: "loadProductOptions",
        value: function loadProductOptions() {
          var _this11 = this;

          if (this.selectedProduct != null) {
            this.productOptionService.getOptionsForProduct(this.selectedProduct.product).subscribe(function (incomingProductOptions) {
              _this11.selectedProductOptions = new Array();
              _this11.possibleProductOptions = new Array();

              if (_this11.incomingPackagedProduct.options !== null && _this11.incomingPackagedProduct.options.length > 0) {
                incomingProductOptions.forEach(function (incomingProductOption) {
                  if (_this11.optionWasSelected(incomingProductOption)) {
                    _this11.selectedProductOptions.push(incomingProductOption);
                  } else {
                    _this11.possibleProductOptions.push(incomingProductOption);
                  }
                });
              } else {
                _this11.possibleProductOptions = incomingProductOptions;
              }
            }, function (error) {
              return _this11.handleError(error);
            });
          }
        }
      }, {
        key: "optionWasSelected",
        value: function optionWasSelected(incomingProductOptions) {
          var returnValue = false;

          if (this.incomingPackagedProduct !== null && this.incomingPackagedProduct.options != null) {
            this.incomingPackagedProduct.options.some(function (packagedOption) {
              if (packagedOption.optionId === incomingProductOptions.id) {
                returnValue = true;
              }

              return returnValue;
            });
          }

          return returnValue;
        }
      }, {
        key: "loadProductAttributes",
        value: function loadProductAttributes() {
          var _this12 = this;

          //todo merge the results from the server with the object model for the packaged product
          if (this.selectedProduct != null) {
            this.productAttributes = new Array(); //we may need to change this to be one call to the server to get the attributes and there possible values instead of this loop with multiple calls to the server

            this.productService.getAttributesForProduct(this.selectedProduct.product).subscribe(function (incomingAttributes) {
              incomingAttributes.forEach(function (attribute) {
                var previouslySelectedDetail = _this12.getProductAttributeIfPreviouslySeleted(attribute); //set up the attribute for the UI controls


                var tempPropertyModel = new propertyModel_1.PropertyModel();
                tempPropertyModel.id = attribute.id;
                tempPropertyModel.name = attribute.name;

                if (previouslySelectedDetail && previouslySelectedDetail.attributeValueId || null) {
                  tempPropertyModel.enteredValue = previouslySelectedDetail.attributeValue;
                } else {
                  var tempPackageProductDetail = new packagedProductDetailModel_1.PackagedProductDetailModel();
                  tempPackageProductDetail.attribute = attribute;

                  _this12.incomingPackagedProduct.details.push(tempPackageProductDetail);

                  previouslySelectedDetail = tempPackageProductDetail;
                }

                _this12.productService.getAttributeValuesForProduct(_this12.selectedProduct.product, attribute).subscribe(function (attributeValues) {
                  if (attributeValues.length > 0) {
                    //the attribute has values so a drop down should be showing and any previously selected value will be
                    //a value in the drop down if the value matches on the attribute value description
                    //this is the best that can be done since the selected attribute value is not saved
                    //it is not saved so the value itself can be deleted by the user
                    tempPropertyModel.enteredValue = null;
                    tempPropertyModel.possibleValues = new Array();
                    attributeValues.forEach(function (attributeValue) {
                      var tempPossibleValueModel = new possibleValueModel_1.PossibleValueModel();
                      tempPossibleValueModel.id = attributeValue.id;
                      tempPossibleValueModel.label = attributeValue.description;
                      tempPossibleValueModel.value = tempPossibleValueModel;
                      tempPropertyModel.possibleValues.push(tempPossibleValueModel);

                      if (previouslySelectedDetail !== null && previouslySelectedDetail.attributeValueId === attributeValue.id) {
                        //the drop down has a previosly selected value and it matches
                        tempPropertyModel.selectedValue = tempPossibleValueModel;
                      } else if (attributeValue.isDefault) {
                        //the drop down has a default value
                        tempPropertyModel.selectedValue = tempPossibleValueModel;
                      }
                    });
                  }

                  _this12.productAttributes.push(tempPropertyModel);
                }, function (error) {
                  return _this12.handleError(error);
                });
              });
            }, function (error) {
              return _this12.handleError(error);
            });
          }
        }
      }, {
        key: "getProductAttributeIfPreviouslySeleted",
        value: function getProductAttributeIfPreviouslySeleted(incomingAttribute) {
          var returnValue = null;

          if (this.incomingPackagedProduct !== null && this.incomingPackagedProduct.details != null) {
            this.incomingPackagedProduct.details.some(function (detail) {
              if (detail.attribute.id === incomingAttribute.id) {
                returnValue = detail;
              }

              return returnValue !== null;
            });
          }

          return returnValue;
        } //private getAttributeValueModelFromPackagedProductDetailModel(previouslySelectedDetail: PackagedProductDetailModel,
        //    attributeValue: ProductAttributeValueModel): AttributeValueModel {
        //    var returnValue: AttributeValueModel = null;
        //    if (previouslySelectedDetail.possibleValues != null) {
        //        previouslySelectedDetail.possibleValues.some((attribute: AttributeValueModel) => {
        //            if (attribute.id === attributeValue.id) {
        //                returnValue = attribute;
        //            }
        //            return returnValue !== null;
        //        });
        //    }
        //    return returnValue;
        //}

      }, {
        key: "handleTabChange",
        value: function handleTabChange(e) {
          this.oldTabIndex = this.tabIndex;
          this.tabIndex = e.index;
          this.tabChanged.emit(this.tabIndex);
        }
      }, {
        key: "processTabChange",
        value: function processTabChange(tabIndex) {
          var _this13 = this;

          debugger; //todo set the data from the old tab into the object model for the packaged product

          if (this.selectedProduct != null) {
            switch (this.oldTabIndex) {
              case PackagedProduct.PRODUCT_TAB:
                if (this.selectedProduct.product.id !== this.incomingPackagedProduct.productId) {
                  //the product has changed
                  this.incomingPackagedProduct.productId = this.selectedProduct.product.id;
                  this.incomingPackagedProduct.details = new Array();
                  this.incomingPackagedProduct.options = new Array();
                }

                this.loadProductOptions();
                this.loadProductAttributes();
                break;

              case PackagedProduct.OPTIONS_TAB:
                if (this.selectedProductOptions != null) {
                  this.incomingPackagedProduct.options = new Array();
                  this.selectedProductOptions.forEach(function (option) {
                    var tempPackagedProductOption = new packagedProductOptionModel_1.PackagedProductOptionModel();
                    tempPackagedProductOption.optionId = option.id;
                    tempPackagedProductOption.details = new Array();

                    _this13.incomingPackagedProduct.options.push(tempPackagedProductOption);
                  });
                }

                break;

              case PackagedProduct.OPTIONS_DETAILS_TAB:
                //todo take the currently selected product option and put the marketing lingo into the packaged object model
                if (this.selectedProductOption != null) {
                  this.saveProductionOptionDetails(this.selectedProductOption);
                }

                break;

              case PackagedProduct.PRODUCT_ATTRIBUTES_TAB:
                this.productAttributes.forEach(function (productAttribute) {
                  _this13.incomingPackagedProduct.details.some(function (detail) {
                    var returnValue = false;

                    if (detail.attribute.id === productAttribute.id) {
                      if (productAttribute.enteredValue != null) {
                        detail.attributeValue = productAttribute.enteredValue;
                      } else {
                        var tempAttributeValue = productAttribute.selectedValue;
                        detail.attributeValueId = tempAttributeValue.id;
                      }

                      returnValue = true;
                    }

                    return returnValue;
                  });
                });
                break;

              case PackagedProduct.OPTIONS_ATTRIBUTES_TAB:
                this.updateOptionAttributeSettings(this.selectedProductOption);
                break;

              case PackagedProduct.PRICE_TAB:
                break;
            } //end of swith on old tab index


            this.oldTabIndex = tabIndex;

            switch (tabIndex) {
              case PackagedProduct.OPTIONS_DETAILS_TAB:
                this.productOptionMarketingLingo = "";

              case PackagedProduct.OPTIONS_ATTRIBUTES_TAB:
                if (this.selectedProduct != null && this.selectedProductOptions != null) {
                  //we hit the option attributes tab so we need to transform the data for the controls on the tab
                  this.productOptionAttributes = null;
                  this.selectedProductOption = null;
                  this.selectedProductOptionsList = null;

                  if (this.selectedProductOptions.length > 0) {
                    this.selectedProductOptionsList = new Array();
                    this.selectedProductOptions.forEach(function (productOption) {
                      var tempProductOption = new productOptionDropDown_1.ProductOptionDropDown();
                      tempProductOption.label = productOption.name;
                      tempProductOption.value = productOption;

                      _this13.selectedProductOptionsList.push(tempProductOption);
                    });
                  }
                }

                break;
            } //end of switch on tab index

          }
        }
      }, {
        key: "updateOptionAttributeSettings",
        value: function updateOptionAttributeSettings(productOption) {
          var _this14 = this;

          if (productOption != null) {
            this.incomingPackagedProduct.options.forEach(function (option) {
              if (productOption.id === option.optionId) {
                _this14.productOptionAttributes.forEach(function (optionAttribute) {
                  option.details.some(function (detail) {
                    var returnValue = false;

                    if (detail.attribute.id === optionAttribute.id) {
                      if (optionAttribute.enteredValue != null) {
                        detail.attributeValue = optionAttribute.enteredValue;
                      } else {
                        var tempAttributeValue = optionAttribute.selectedValue;
                        detail.attributeValueId = tempAttributeValue.id;
                      }

                      returnValue = true;
                    }

                    return returnValue;
                  });
                });
              }
            });
          }
        }
      }, {
        key: "handleProductOptionDropDownForOptionsDetailsTabChange",
        value: function handleProductOptionDropDownForOptionsDetailsTabChange(event) {
          var _this15 = this;

          //todo take the currently selected product option and put the marketing lingo into the packaged object model
          var productOption = event.value;

          if (this.oldProductOption != null) {
            this.saveProductionOptionDetails(this.oldProductOption);
          }

          if (productOption != null) {
            this.oldProductOption = productOption;
            this.incomingPackagedProduct.options.some(function (option) {
              var returnValue = false;

              if (option.optionId === productOption.id) {
                _this15.productOptionMarketingLingo = option.description;
                returnValue = true;
              }

              return returnValue;
            });
          }
        }
      }, {
        key: "saveProductionOptionDetails",
        value: function saveProductionOptionDetails(productOption) {
          var _this16 = this;

          this.incomingPackagedProduct.options.some(function (option) {
            var returnValue = false;

            if (option.optionId === productOption.id) {
              option.description = _this16.productOptionMarketingLingo;
              returnValue = true;
            }

            return returnValue;
          });
        }
      }, {
        key: "handleProductOptionDropDownForOptionAttributesTabChange",
        value: function handleProductOptionDropDownForOptionAttributesTabChange(event) {
          var _this17 = this;

          var productOption = event.value;

          if (productOption != null) {
            if (this.oldproductOption != null && this.oldproductOption.id != productOption.id) {
              this.updateOptionAttributeSettings(this.oldProductOption);
            }

            this.oldproductOption = productOption;
            var packagedProductOption;
            this.incomingPackagedProduct.options.some(function (option) {
              if (productOption.id === option.optionId) {
                packagedProductOption = option;
                return;
              }
            });
            this.productOptionAttributes = new Array(); //we may need to change this to be one call to the server to get the attributes and there possible values instead of this loop with multiple calls to the server

            this.productOptionService.getAttributesForProductOption(this.selectedProduct.product, productOption).subscribe(function (incomingAttributes) {
              incomingAttributes.forEach(function (attribute) {
                //make sure we have a place to store the results of the user's settings
                var packagedProductOptionDetail = null;
                packagedProductOption.details.some(function (detail) {
                  if (detail.attribute.id === attribute.id) packagedProductOptionDetail = detail;
                  return;
                });

                if (packagedProductOptionDetail == null) {
                  packagedProductOptionDetail = new packagedProductOptionDetailModel_1.PackagedProductOptionDetailModel();
                  packagedProductOptionDetail.attribute = attribute;
                  packagedProductOptionDetail.attributeValue = null;
                  packagedProductOptionDetail.attributeValueId = null;
                  packagedProductOption.details.push(packagedProductOptionDetail);
                } //set up the settings


                var tempPropertyModel = new propertyModel_1.PropertyModel();
                tempPropertyModel.id = attribute.id;
                tempPropertyModel.name = attribute.name;

                _this17.productOptionService.getAttributeValuesForProductOption(_this17.selectedProduct.product, productOption, attribute).subscribe(function (attributeValues) {
                  var found = false;

                  if (attributeValues.length > 0) {
                    tempPropertyModel.possibleValues = new Array();
                    attributeValues.forEach(function (attributeValue) {
                      var tempPossibleValueModel = new possibleValueModel_1.PossibleValueModel();
                      tempPossibleValueModel.id = attributeValue.id;
                      tempPossibleValueModel.label = attributeValue.description;
                      tempPossibleValueModel.value = attributeValue;
                      tempPropertyModel.possibleValues.push(tempPossibleValueModel);

                      if (tempPropertyModel.selectedValue == null && (attributeValue.isDefault || attributeValue.id === packagedProductOptionDetail.attributeValueId)) {
                        tempPropertyModel.selectedValue = tempPossibleValueModel;
                      }
                    });
                  } else if (packagedProductOptionDetail.attributeValue !== null) {
                    tempPropertyModel.enteredValue = packagedProductOptionDetail.attributeValue;
                  }

                  _this17.productOptionAttributes.push(tempPropertyModel);
                }, function (error) {
                  return _this17.handleError(error);
                });
              });
            }, function (error) {
              return _this17.handleError(error);
            });
          }
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear();
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }, {
        key: "packagedProduct",
        set: function set(value) {
          var _this18 = this;

          this.incomingPackagedProduct = value;
          this.selectedProduct = null;

          if (this.productList != null) {
            this.productList.forEach(function (pricedProduct) {
              if (_this18.incomingPackagedProduct.productId === pricedProduct.value.product.id) {
                _this18.selectedProduct = pricedProduct.value;
              }
            }); //TODO populate the rest of the object models for the controls
          }
        },
        get: function get() {
          return this.incomingPackagedProduct;
        }
      }, {
        key: "tabNumber",
        set: function set(value) {
          this.tabIndex = value;
          this.processTabChange(this.tabIndex);
        },
        get: function get() {
          return this.tabIndex;
        }
      }]);

      return PackagedProduct;
    }();

    exports.PackagedProduct = PackagedProduct; //consts
    // ReSharper disable InconsistentNaming

    PackagedProduct.PRODUCT_TAB = 0;
    PackagedProduct.OPTIONS_TAB = 1;
    PackagedProduct.OPTIONS_DETAILS_TAB = 2;
    PackagedProduct.PRODUCT_ATTRIBUTES_TAB = 3;
    PackagedProduct.OPTIONS_ATTRIBUTES_TAB = 4;
    PackagedProduct.PRICE_TAB = 5;

    PackagedProduct.??fac = function PackagedProduct_Factory(t) {
      return new (t || PackagedProduct)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.ProductService), i0.????directiveInject(i3.ProductOptionService));
    };

    PackagedProduct.??cmp = i0.????defineComponent({
      type: PackagedProduct,
      selectors: [["packagedProduct"]],
      inputs: {
        packagedProduct: "packagedProduct",
        tabNumber: "tabNumber"
      },
      outputs: {
        tabChanged: "tabChanged"
      },
      decls: 14,
      vars: 8,
      consts: [[4, "ngIf"], [3, "activeIndex", "onChange"], ["header", "Product"], ["class", "ui-g-12", 4, "ngIf"], ["header", "Options"], ["header", "Options Details"], ["header", "Product Attributes"], ["header", "Options Attributes"], ["header", "Price"], [1, "ui-g-12"], ["placeholder", "Select a Product", 3, "options", "ngModel", "styleClass", "ngModelChange"], ["pInputTextarea", "", 3, "rows", "cols", "ngModel", "ngModelChange"], ["size", "30", "placeholder", "", 3, "ngModel", "min", "step", "ngModelChange"], [3, "sourceHeader", "source", "targetHeader", "target", "showSourceControls", "showTargetControls"], ["pTemplate", "item"], ["placeholder", "Select a Product Option", 3, "options", "ngModel", "styleClass", "ngModelChange", "onChange"], [3, "ngModel", "ngModelChange"]],
      template: function PackagedProduct_Template(rf, ctx) {
        if (rf & 1) {
          i0.????template(0, PackagedProduct_div_0_Template, 3, 2, "div", 0);
          i0.????elementStart(1, "p-tabView", 1);
          i0.????listener("onChange", function PackagedProduct_Template_p_tabView_onChange_1_listener($event) {
            return ctx.handleTabChange($event);
          });
          i0.????elementStart(2, "p-tabPanel", 2);
          i0.????template(3, PackagedProduct_div_3_Template, 4, 3, "div", 3);
          i0.????template(4, PackagedProduct_div_4_Template, 8, 6, "div", 3);
          i0.????elementEnd();
          i0.????elementStart(5, "p-tabPanel", 4);
          i0.????template(6, PackagedProduct_div_6_Template, 3, 6, "div", 3);
          i0.????elementEnd();
          i0.????elementStart(7, "p-tabPanel", 5);
          i0.????template(8, PackagedProduct_div_8_Template, 7, 6, "div", 0);
          i0.????elementEnd();
          i0.????elementStart(9, "p-tabPanel", 6);
          i0.????template(10, PackagedProduct_div_10_Template, 2, 1, "div", 3);
          i0.????elementEnd();
          i0.????elementStart(11, "p-tabPanel", 7);
          i0.????template(12, PackagedProduct_div_12_Template, 5, 4, "div", 3);
          i0.????elementEnd();
          i0.????element(13, "p-tabPanel", 8);
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("ngIf", ctx.selectedProduct != null);
          i0.????advance(1);
          i0.????property("activeIndex", ctx.tabIndex);
          i0.????advance(2);
          i0.????property("ngIf", ctx.validProducts);
          i0.????advance(1);
          i0.????property("ngIf", ctx.incomingPackagedProduct);
          i0.????advance(2);
          i0.????property("ngIf", ctx.selectedProduct);
          i0.????advance(2);
          i0.????property("ngIf", ctx.selectedProduct && ctx.selectedProductOptions);
          i0.????advance(2);
          i0.????property("ngIf", ctx.selectedProduct && ctx.productAttributes);
          i0.????advance(2);
          i0.????property("ngIf", ctx.selectedProductOptionsList);
        }
      },
      directives: [i4.NgIf, i5.TabView, i5.TabPanel, i6.Dropdown, i7.NgControlStatus, i7.NgModel, i7.DefaultValueAccessor, i8.Spinner, i9.PickList, i1.PrimeTemplate, i10.PropertyBag],
      styles: [".dropDownCol[_ngcontent-%COMP%] {\r\n    overflow: visible;\r\n    width: 350px !important;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvY29tcG9uZW50cy9wYWNrYWdlZFByb2R1Y3QvcGFja2FnZWRQcm9kdWN0LmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7SUFDSSxpQkFBaUI7SUFDakIsdUJBQXVCO0FBQzNCIiwiZmlsZSI6InNyYy9hcHAvY29tcG9uZW50cy9wYWNrYWdlZFByb2R1Y3QvcGFja2FnZWRQcm9kdWN0LmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuZHJvcERvd25Db2wge1xyXG4gICAgb3ZlcmZsb3c6IHZpc2libGU7XHJcbiAgICB3aWR0aDogMzUwcHggIWltcG9ydGFudDtcclxufVxyXG4iXX0= */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(PackagedProduct, [{
        type: core_1.Component,
        args: [{
          selector: 'packagedProduct',
          templateUrl: './packagedProduct.component.html',
          styleUrls: ['./packagedProduct.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.ProductService
        }, {
          type: i3.ProductOptionService
        }];
      }, {
        packagedProduct: [{
          type: core_1.Input
        }],
        tabNumber: [{
          type: core_1.Input
        }],
        tabChanged: [{
          type: core_1.Output
        }]
      });
    })();
    /***/

  },

  /***/
  "./src/app/components/price/price.component.ts":
  /*!*****************************************************!*\
    !*** ./src/app/components/price/price.component.ts ***!
    \*****************************************************/

  /*! no static exports found */

  /***/
  function srcAppComponentsPricePriceComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js"); //models


    var priceModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/priceModel */
    "./src/commonComponents/models/products/priceModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/calendar */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-calendar.js");

    var i2 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i3 = __webpack_require__(
    /*! primeng/spinner */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-spinner.js");

    var i4 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var i5 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function PriceComponent_div_8_Template(rf, ctx) {
      if (rf & 1) {
        var _r2 = i0.????getCurrentView();

        i0.????elementStart(0, "div");
        i0.????text(1, " Formula Price ");
        i0.????elementStart(2, "input", 3);
        i0.????listener("ngModelChange", function PriceComponent_div_8_Template_input_ngModelChange_2_listener($event) {
          i0.????restoreView(_r2);
          var ctx_r1 = i0.????nextContext();
          return ctx_r1.priceData.formulaPrice = $event;
        });
        i0.????elementEnd();
        i0.????elementStart(3, "span", 4);
        i0.????listener("innerText", function PriceComponent_div_8_Template_span_innerText_3_listener() {
          i0.????restoreView(_r2);
          var ctx_r3 = i0.????nextContext();
          return ctx_r3.priceData.formulaPrice;
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r0 = i0.????nextContext();
        i0.????advance(2);
        i0.????propertyInterpolate("title", ctx_r0.priceData.formulaVariablesFormatted);
        i0.????property("ngModel", ctx_r0.priceData.formulaPrice);
      }
    }

    var PriceComponent = /*#__PURE__*/function () {
      function PriceComponent() {
        _classCallCheck(this, PriceComponent);

        this.showFormula = true;
      }

      _createClass(PriceComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          if (this.priceData == null) {
            this.priceData = new priceModel_1.PriceModel();
          }
        }
      }]);

      return PriceComponent;
    }();

    exports.PriceComponent = PriceComponent;

    PriceComponent.??fac = function PriceComponent_Factory(t) {
      return new (t || PriceComponent)();
    };

    PriceComponent.??cmp = i0.????defineComponent({
      type: PriceComponent,
      selectors: [["price"]],
      inputs: {
        priceData: "priceData",
        showFormula: "showFormula"
      },
      decls: 9,
      vars: 8,
      consts: [[3, "ngModel", "inline", "ngModelChange"], [1, "currency", 3, "ngModel", "min", "step", "ngModelChange"], [4, "ngIf"], ["type", "text", "pInputText", "", 3, "title", "ngModel", "ngModelChange"], [3, "innerText"]],
      template: function PriceComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????text(0, " Price Start\n");
          i0.????elementStart(1, "p-calendar", 0);
          i0.????listener("ngModelChange", function PriceComponent_Template_p_calendar_ngModelChange_1_listener($event) {
            return ctx.priceData.startDateTime = $event;
          });
          i0.????elementEnd();
          i0.????text(2, "\nPrice End\n");
          i0.????elementStart(3, "p-calendar", 0);
          i0.????listener("ngModelChange", function PriceComponent_Template_p_calendar_ngModelChange_3_listener($event) {
            return ctx.priceData.endDateTime = $event;
          });
          i0.????elementEnd();
          i0.????element(4, "br");
          i0.????text(5, "\nFlat Price\n");
          i0.????elementStart(6, "p-spinner", 1);
          i0.????listener("ngModelChange", function PriceComponent_Template_p_spinner_ngModelChange_6_listener($event) {
            return ctx.priceData.flatPrice = $event;
          });
          i0.????elementEnd();
          i0.????element(7, "br");
          i0.????template(8, PriceComponent_div_8_Template, 4, 2, "div", 2);
        }

        if (rf & 2) {
          i0.????advance(1);
          i0.????property("ngModel", ctx.priceData.startDateTime)("inline", true);
          i0.????advance(2);
          i0.????property("ngModel", ctx.priceData.endDateTime)("inline", true);
          i0.????advance(3);
          i0.????property("ngModel", ctx.priceData.flatPrice)("min", 0)("step", 0.01);
          i0.????advance(2);
          i0.????property("ngIf", ctx.showFormula);
        }
      },
      directives: [i1.Calendar, i2.NgControlStatus, i2.NgModel, i3.Spinner, i4.NgIf, i2.DefaultValueAccessor, i5.InputText],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvcHJpY2UvcHJpY2UuY29tcG9uZW50LmNzcyJ9 */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(PriceComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'price',
          templateUrl: './price.component.html',
          styleUrls: ['./price.component.css']
        }]
      }], function () {
        return [];
      }, {
        priceData: [{
          type: core_1.Input
        }],
        showFormula: [{
          type: core_1.Input
        }]
      });
    })();
    /***/

  },

  /***/
  "./src/app/components/productOptions/productOptions.component.ts":
  /*!***********************************************************************!*\
    !*** ./src/app/components/productOptions/productOptions.component.ts ***!
    \***********************************************************************/

  /*! no static exports found */

  /***/
  function srcAppComponentsProductOptionsProductOptionsComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js"); //models


    var productOptionModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/productOptionModel */
    "./src/commonComponents/models/products/productOptionModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../../commonComponents/service/productOption.service */
    "./src/commonComponents/service/productOption.service.ts");

    var i3 = __webpack_require__(
    /*! primeng/table */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-table.js");

    var i4 = __webpack_require__(
    /*! primeng/dialog */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dialog.js");

    var i5 = __webpack_require__(
    /*! ../../../commonComponents/components/productOption/productOption.component */
    "./src/commonComponents/components/productOption/productOption.component.ts");

    var i6 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i7 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function ProductOptionsComponent_ng_template_2_Template(rf, ctx) {
      if (rf & 1) {
        var _r4 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "th");
        i0.????elementStart(2, "button", 9);
        i0.????listener("click", function ProductOptionsComponent_ng_template_2_Template_button_click_2_listener() {
          i0.????restoreView(_r4);
          var ctx_r3 = i0.????nextContext();
          return ctx_r3.clickNewProductOptionDialog();
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "th", 10);
        i0.????text(4, "Name");
        i0.????element(5, "p-sortIcon", 11);
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(6, "tr");
        i0.????element(7, "th");
        i0.????elementStart(8, "th");
        i0.????elementStart(9, "input", 12);
        i0.????listener("input", function ProductOptionsComponent_ng_template_2_Template_input_input_9_listener($event) {
          i0.????restoreView(_r4);
          i0.????nextContext();

          var _r0 = i0.????reference(1);

          return _r0.filter($event.target.value, "name", "contains");
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }
    }

    function ProductOptionsComponent_ng_template_3_Template(rf, ctx) {
      if (rf & 1) {
        var _r8 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "td");
        i0.????elementStart(2, "button", 13);
        i0.????listener("click", function ProductOptionsComponent_ng_template_3_Template_button_click_2_listener() {
          i0.????restoreView(_r8);
          var productOption_r6 = ctx.$implicit;
          var ctx_r7 = i0.????nextContext();
          return ctx_r7.clickDetailOptionDialog(productOption_r6);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "td");
        i0.????text(4);
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var productOption_r6 = ctx.$implicit;
        i0.????advance(4);
        i0.????textInterpolate(productOption_r6.name);
      }
    }

    var ProductOptionsComponent = /*#__PURE__*/function () {
      function ProductOptionsComponent(messageService, dataService) {
        _classCallCheck(this, ProductOptionsComponent);

        this.messageService = messageService;
        this.dataService = dataService;
        this.productOptionData = new Array();
      }

      _createClass(ProductOptionsComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.loadProductOptions();
        }
      }, {
        key: "loadProductOptions",
        value: function loadProductOptions() {
          var _this19 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Loading Products'
          });
          this.dataService.getProductOptions().subscribe(function (dataSet) {
            _this19.productOptionData = dataSet;
            _this19.messageService.clear;
          }, function (ex) {
            return _this19.handleError(ex);
          });
        }
      }, {
        key: "clickNewProductOptionDialog",
        value: function clickNewProductOptionDialog() {
          if (this.newProductOption == null) this.newProductOption = new productOptionModel_1.ProductOptionModel();
          this.showNewProductOptionDialog = true;
        }
      }, {
        key: "createNewProductOptionDialogClick",
        value: function createNewProductOptionDialogClick() {
          var _this20 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Saving Product'
          });
          var productOptionToUpload = this.newProductOption;
          this.dataService.setProductOption(productOptionToUpload).subscribe(function () {
            return _this20.loadProductOptions();
          }, function (error) {
            return _this20.handleError(error);
          });
          this.showNewProductOptionDialog = false;
        }
      }, {
        key: "clickDetailOptionDialog",
        value: function clickDetailOptionDialog(productOption) {
          this.selectedProductOption = productOption;
          this.showProductOptionDetailDialog = true;
        }
      }, {
        key: "saveProductOptionDetailDialogClick",
        value: function saveProductOptionDetailDialogClick() {
          var _this21 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Saving Product'
          });
          var productOptionToUpload = this.selectedProductOption;
          this.dataService.setProductOption(productOptionToUpload).subscribe(function () {
            _this21.messageService.clear();
          }, function (error) {
            return _this21.handleError(error);
          });
          this.showProductOptionDetailDialog = false;
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear();
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }]);

      return ProductOptionsComponent;
    }();

    exports.ProductOptionsComponent = ProductOptionsComponent;

    ProductOptionsComponent.??fac = function ProductOptionsComponent_Factory(t) {
      return new (t || ProductOptionsComponent)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.ProductOptionService));
    };

    ProductOptionsComponent.??cmp = i0.????defineComponent({
      type: ProductOptionsComponent,
      selectors: [["productOptions"]],
      decls: 12,
      vars: 9,
      consts: [[3, "value", "rows", "paginator"], ["productOptionTable", ""], ["pTemplate", "header"], ["pTemplate", "body"], ["header", "Create New Option", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], [3, "ProductOptionData"], ["type", "button", "pButton", "", "label", "Create Option", 3, "click"], ["header", "Option Details", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], ["type", "button", "pButton", "", "label", "Save Option", 3, "click"], ["type", "button", "pButton", "", "label", "Add", 3, "click"], ["pSortableColumn", "name"], ["field", "name"], ["pInputText", "", "type", "text", 3, "input"], ["type", "button", "pButton", "", "icon", "fa fa-binoculars", 3, "click"]],
      template: function ProductOptionsComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "p-table", 0, 1);
          i0.????template(2, ProductOptionsComponent_ng_template_2_Template, 10, 0, "ng-template", 2);
          i0.????template(3, ProductOptionsComponent_ng_template_3_Template, 5, 1, "ng-template", 3);
          i0.????elementEnd();
          i0.????elementStart(4, "p-dialog", 4);
          i0.????listener("visibleChange", function ProductOptionsComponent_Template_p_dialog_visibleChange_4_listener($event) {
            return ctx.showNewProductOptionDialog = $event;
          });
          i0.????element(5, "productOption", 5);
          i0.????elementStart(6, "p-footer");
          i0.????elementStart(7, "button", 6);
          i0.????listener("click", function ProductOptionsComponent_Template_button_click_7_listener() {
            return ctx.createNewProductOptionDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(8, "p-dialog", 7);
          i0.????listener("visibleChange", function ProductOptionsComponent_Template_p_dialog_visibleChange_8_listener($event) {
            return ctx.showProductOptionDetailDialog = $event;
          });
          i0.????element(9, "productOption", 5);
          i0.????elementStart(10, "p-footer");
          i0.????elementStart(11, "button", 8);
          i0.????listener("click", function ProductOptionsComponent_Template_button_click_11_listener() {
            return ctx.saveProductOptionDetailDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("value", ctx.productOptionData)("rows", 10)("paginator", true);
          i0.????advance(4);
          i0.????property("visible", ctx.showNewProductOptionDialog)("closable", true);
          i0.????advance(1);
          i0.????property("ProductOptionData", ctx.newProductOption);
          i0.????advance(3);
          i0.????property("visible", ctx.showProductOptionDetailDialog)("closable", true);
          i0.????advance(1);
          i0.????property("ProductOptionData", ctx.selectedProductOption);
        }
      },
      directives: [i3.Table, i1.PrimeTemplate, i4.Dialog, i5.ProductOptionComponent, i1.Footer, i6.ButtonDirective, i3.SortableColumn, i3.SortIcon, i7.InputText],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvcHJvZHVjdE9wdGlvbnMvcHJvZHVjdE9wdGlvbnMuY29tcG9uZW50LmNzcyJ9 */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductOptionsComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'productOptions',
          templateUrl: './productOptions.component.html',
          styleUrls: ['./productOptions.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.ProductOptionService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/components/productSetup/productSetup.component.ts":
  /*!*******************************************************************!*\
    !*** ./src/app/components/productSetup/productSetup.component.ts ***!
    \*******************************************************************/

  /*! no static exports found */

  /***/
  function srcAppComponentsProductSetupProductSetupComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var productOptionDropDown_1 = __webpack_require__(
    /*! ../../models/productOptionDropDown */
    "./src/app/models/productOptionDropDown.ts");

    var attributeDropDown_1 = __webpack_require__(
    /*! ../../models/attributeDropDown */
    "./src/app/models/attributeDropDown.ts");

    var productAttributeValueCreator_1 = __webpack_require__(
    /*! ../../../commonComponents/helpers/productAttributeValueCreator */
    "./src/commonComponents/helpers/productAttributeValueCreator.ts");

    var productOptionAttributeValueCreator_1 = __webpack_require__(
    /*! ../../../commonComponents/helpers/productOptionAttributeValueCreator */
    "./src/commonComponents/helpers/productOptionAttributeValueCreator.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../../commonComponents/service/product.service */
    "./src/commonComponents/service/product.service.ts");

    var i3 = __webpack_require__(
    /*! ../../../commonComponents/service/productOption.service */
    "./src/commonComponents/service/productOption.service.ts");

    var i4 = __webpack_require__(
    /*! ../../../commonComponents/service/attribute.service */
    "./src/commonComponents/service/attribute.service.ts");

    var i5 = __webpack_require__(
    /*! primeng/fieldset */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-fieldset.js");

    var i6 = __webpack_require__(
    /*! primeng/dropdown */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dropdown.js");

    var i7 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i8 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var i9 = __webpack_require__(
    /*! primeng/picklist */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-picklist.js");

    var i10 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i11 = __webpack_require__(
    /*! ../../../commonComponents/components/listEntry/listEntry.component */
    "./src/commonComponents/components/listEntry/listEntry.component.ts");

    function ProductSetupComponent_div_8_Template(rf, ctx) {
      if (rf & 1) {
        var _r4 = i0.????getCurrentView();

        i0.????elementStart(0, "div");
        i0.????elementStart(1, "div", 3);
        i0.????elementStart(2, "listEntry", 13);
        i0.????listener("valuesChanged", function ProductSetupComponent_div_8_Template_listEntry_valuesChanged_2_listener($event) {
          i0.????restoreView(_r4);
          var ctx_r3 = i0.????nextContext();
          return ctx_r3.productAttributeValuesChanged($event);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "div", 14);
        i0.????text(4, " Default Value");
        i0.????element(5, "br");
        i0.????elementStart(6, "p-dropdown", 4);
        i0.????listener("ngModelChange", function ProductSetupComponent_div_8_Template_p_dropdown_ngModelChange_6_listener($event) {
          i0.????restoreView(_r4);
          var ctx_r5 = i0.????nextContext();
          return ctx_r5.defaultProductAttributeValue = $event;
        })("onChange", function ProductSetupComponent_div_8_Template_p_dropdown_onChange_6_listener($event) {
          i0.????restoreView(_r4);
          var ctx_r6 = i0.????nextContext();
          return ctx_r6.handleDefaultProductAttributeValueChange($event);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(7, "div", 10);
        i0.????elementStart(8, "button", 15);
        i0.????listener("click", function ProductSetupComponent_div_8_Template_button_click_8_listener() {
          i0.????restoreView(_r4);
          var ctx_r7 = i0.????nextContext();
          return ctx_r7.clickSaveProductAttributeValues();
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r0 = i0.????nextContext();
        i0.????advance(2);
        i0.????property("disabled", ctx_r0.disableProductAttributeValue)("Creator", ctx_r0.productAttributeValueCreater)("EnteryValues", ctx_r0.productAttributeValues);
        i0.????advance(4);
        i0.????property("options", ctx_r0.productAttributeValues)("ngModel", ctx_r0.defaultProductAttributeValue);
        i0.????advance(2);
        i0.????property("disabled", ctx_r0.disableProductAttributeValue);
      }
    }

    function ProductSetupComponent_ng_template_17_Template(rf, ctx) {
      if (rf & 1) {
        i0.????text(0);
      }

      if (rf & 2) {
        var option_r8 = ctx.$implicit;
        i0.????textInterpolate1(" ", option_r8.name, " ");
      }
    }

    function ProductSetupComponent_div_22_div_5_div_5_Template(rf, ctx) {
      if (rf & 1) {
        var _r12 = i0.????getCurrentView();

        i0.????elementStart(0, "div");
        i0.????elementStart(1, "div", 3);
        i0.????elementStart(2, "listEntry", 13);
        i0.????listener("valuesChanged", function ProductSetupComponent_div_22_div_5_div_5_Template_listEntry_valuesChanged_2_listener($event) {
          i0.????restoreView(_r12);
          var ctx_r11 = i0.????nextContext(3);
          return ctx_r11.productOptionAttributeValuesChanged($event);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "div", 14);
        i0.????text(4, " Default Value");
        i0.????element(5, "br");
        i0.????elementStart(6, "p-dropdown", 4);
        i0.????listener("ngModelChange", function ProductSetupComponent_div_22_div_5_div_5_Template_p_dropdown_ngModelChange_6_listener($event) {
          i0.????restoreView(_r12);
          var ctx_r13 = i0.????nextContext(3);
          return ctx_r13.defaultProductOptionAttributeValue = $event;
        })("onChange", function ProductSetupComponent_div_22_div_5_div_5_Template_p_dropdown_onChange_6_listener($event) {
          i0.????restoreView(_r12);
          var ctx_r14 = i0.????nextContext(3);
          return ctx_r14.handleDefaultProductOptionAttributeValueChange($event);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(7, "div", 10);
        i0.????elementStart(8, "button", 15);
        i0.????listener("click", function ProductSetupComponent_div_22_div_5_div_5_Template_button_click_8_listener() {
          i0.????restoreView(_r12);
          var ctx_r15 = i0.????nextContext(3);
          return ctx_r15.clickSaveProductOptionAttributeValues();
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r10 = i0.????nextContext(3);
        i0.????advance(2);
        i0.????property("disabled", ctx_r10.disableProductOptionAttributeValue)("Creator", ctx_r10.productOptionAttributeValueCreater)("EnteryValues", ctx_r10.productOptionAttributeValues);
        i0.????advance(4);
        i0.????property("options", ctx_r10.productOptionAttributeValues)("ngModel", ctx_r10.defaultProductOptionAttributeValue);
        i0.????advance(2);
        i0.????property("disabled", ctx_r10.disableProductOptionAttributeValue);
      }
    }

    function ProductSetupComponent_div_22_div_5_Template(rf, ctx) {
      if (rf & 1) {
        var _r17 = i0.????getCurrentView();

        i0.????elementStart(0, "div", 10);
        i0.????elementStart(1, "div", 3);
        i0.????text(2, " Product Attribute");
        i0.????element(3, "br");
        i0.????elementStart(4, "p-dropdown", 4);
        i0.????listener("ngModelChange", function ProductSetupComponent_div_22_div_5_Template_p_dropdown_ngModelChange_4_listener($event) {
          i0.????restoreView(_r17);
          var ctx_r16 = i0.????nextContext(2);
          return ctx_r16.selectedProductOptionAttribute = $event;
        })("onChange", function ProductSetupComponent_div_22_div_5_Template_p_dropdown_onChange_4_listener($event) {
          i0.????restoreView(_r17);
          var ctx_r18 = i0.????nextContext(2);
          return ctx_r18.handleProductOptionAttributeChange($event);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????template(5, ProductSetupComponent_div_22_div_5_div_5_Template, 9, 6, "div", 5);
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r9 = i0.????nextContext(2);
        i0.????advance(4);
        i0.????property("options", ctx_r9.productOptionAttributeList)("ngModel", ctx_r9.selectedProductOptionAttribute);
        i0.????advance(1);
        i0.????property("ngIf", ctx_r9.showPrductOptionAttributeValues);
      }
    }

    function ProductSetupComponent_div_22_Template(rf, ctx) {
      if (rf & 1) {
        var _r20 = i0.????getCurrentView();

        i0.????elementStart(0, "div");
        i0.????elementStart(1, "div", 10);
        i0.????text(2, " Product Option");
        i0.????element(3, "br");
        i0.????elementStart(4, "p-dropdown", 4);
        i0.????listener("ngModelChange", function ProductSetupComponent_div_22_Template_p_dropdown_ngModelChange_4_listener($event) {
          i0.????restoreView(_r20);
          var ctx_r19 = i0.????nextContext();
          return ctx_r19.selectedProductOptionForAttributeValue = $event;
        })("onChange", function ProductSetupComponent_div_22_Template_p_dropdown_onChange_4_listener($event) {
          i0.????restoreView(_r20);
          var ctx_r21 = i0.????nextContext();
          return ctx_r21.handleProductOptionForAttributeValueChange($event);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????template(5, ProductSetupComponent_div_22_div_5_Template, 6, 3, "div", 16);
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r2 = i0.????nextContext();
        i0.????advance(4);
        i0.????property("options", ctx_r2.productOptionForAttributeValueList)("ngModel", ctx_r2.selectedProductOptionForAttributeValue);
        i0.????advance(1);
        i0.????property("ngIf", ctx_r2.showDetail);
      }
    }

    var ProductSetupComponent = /*#__PURE__*/function () {
      function ProductSetupComponent(messageService, dataService, prodOptionService, attributeService) {
        var _this22 = this;

        _classCallCheck(this, ProductSetupComponent);

        this.messageService = messageService;
        this.dataService = dataService;
        this.prodOptionService = prodOptionService;
        this.attributeService = attributeService;
        this.selectedProductOption = null;
        this.productOptionAttributeSourceHeading = "Available Attributes";
        this.productOptionAttributeTargetHeader = "Associated Attributes";
        this.validProductOption = false;
        this.selectedProductAttribute = null;
        this.defaultProductAttributeValue = null;
        this.selectedProductOptionForAttributeValue = null;
        this.selectedProductOptionAttribute = null;
        this.defaultProductOptionAttributeValue = null;
        this.productAttributeValues = new Array();
        this.productAttributeValueCreater = new productAttributeValueCreator_1.ProductAttributeValueCreator();
        this.productOptionAttributeValueCreater = new productOptionAttributeValueCreator_1.ProductOptionAttributeValueCreator();
        this.disableProductAttributeValue = true;
        this.attributeService.getAttributes().subscribe(function (attributes) {
          _this22.allAttributes = attributes;
        });
      } //part of the component lifecycle - called when changes to the input properties


      _createClass(ProductSetupComponent, [{
        key: "ngOnChanges",
        value: function ngOnChanges(changes) {
          var _this23 = this;

          //this commented code is for reference is case we need to get the current product from the changes
          //for (let propName in changes) {
          //    let chng = changes[propName];
          //    let cur = chng.currentValue;
          //    let prev = chng.previousValue;
          //    if (propName === 'product') {
          //        var obj = cur;
          //        this.product = ProductModelParser.parseObjectIntoProduct(obj);
          //    }
          //}
          this.productAttributeValues = new Array();
          this.productAttributeList = new Array();
          this.productOptionList = new Array();
          this.productOptionForAttributeValueList = new Array();
          this.selectedProductOptionForAttributeValue = null;
          this.showDetail = false;

          if (this.product != null) {
            //get the attributes for the product
            this.dataService.getAttributesForProduct(this.product).subscribe(function (attributes) {
              _this23.selectedProductAttribute = new attributeDropDown_1.AttributeDropDown();

              if (attributes.length < 1) {
                _this23.showPrductAttributeValues = false;
                _this23.selectedProductAttribute.label = 'No Attributes associated with Product';
              } else {
                _this23.showPrductAttributeValues = true;
                _this23.selectedProductAttribute.label = 'Select an Attribute';
              }

              _this23.productAttributeList.push(_this23.selectedProductAttribute);

              attributes.forEach(function (attribute) {
                var attributeDropDownItem = new attributeDropDown_1.AttributeDropDown();
                attributeDropDownItem.label = attribute.name;
                attributeDropDownItem.value = attribute;

                _this23.productAttributeList.push(attributeDropDownItem);
              });
            }, function (error) {
              return _this23.handleError(error);
            }); //get the options for the product

            this.prodOptionService.getOptionsForProduct(this.product).subscribe(function (productOptions) {
              _this23.selectedProductOption = new productOptionDropDown_1.ProductOptionDropDown();
              _this23.selectedProductOptionForAttributeValue = new productOptionDropDown_1.ProductOptionDropDown();
              ;
              var defaultDisplayValue;

              if (productOptions.length < 1) {
                defaultDisplayValue = 'No Options associated with Product';
              } else {
                defaultDisplayValue = 'Select an Option';
              }

              _this23.selectedProductOption.label = defaultDisplayValue;
              _this23.selectedProductOptionForAttributeValue.label = defaultDisplayValue;

              _this23.productOptionList.push(_this23.selectedProductOption);

              _this23.productOptionForAttributeValueList.push(_this23.selectedProductOption);

              productOptions.forEach(function (productOption) {
                var productOptionDropDownItem = new productOptionDropDown_1.ProductOptionDropDown();
                productOptionDropDownItem.label = productOption.name;
                productOptionDropDownItem.value = productOption;

                _this23.productOptionList.push(productOptionDropDownItem);

                _this23.productOptionForAttributeValueList.push(productOptionDropDownItem);
              });
            }, function (error) {
              return _this23.handleError(error);
            });
          }
        } //associate attributes with product option

      }, {
        key: "handleProductOptionChange",
        value: function handleProductOptionChange(event) {
          var _this24 = this;

          this.attributes = new Array();
          this.possibleAttributes = new Array();
          this.validProductOption = false;

          if (this.selectedProductOption != null) {
            this.prodOptionService.getAttributesForProductOption(this.product, this.selectedProductOption).subscribe(function (attributes) {
              _this24.attributes = attributes;
              _this24.possibleAttributes = new Array();

              _this24.allAttributes.forEach(function (att) {
                if (_this24.isProductAttributeAssociated(att) === false) {
                  _this24.possibleAttributes.push(att);
                }
              });

              _this24.validProductOption = true;
            });
          }
        }
      }, {
        key: "isProductAttributeAssociated",
        value: function isProductAttributeAssociated(attribute) {
          var returnValue = false;

          for (var sub = 0; sub < this.attributes.length; sub++) {
            var associatedAttribute = this.attributes[sub];

            if (associatedAttribute.id === attribute.id) {
              returnValue = true;
              break;
            }
          }

          return returnValue;
        }
      }, {
        key: "clickSaveAttributes",
        value: function clickSaveAttributes() {
          var _this25 = this;

          this.prodOptionService.setAttributesForProductOption(this.product, this.selectedProductOption, this.attributes).subscribe(function () {
            _this25.messageService.clear();

            _this25.attributes = new Array();
            _this25.possibleAttributes = new Array();
            _this25.validProductOption = false;
            _this25.selectedProductOption = null; //reset the product option attribute values section

            _this25.selectedProductOptionForAttributeValue = null;
            _this25.productOptionAttributeValues = null;
            _this25.showDetail = false;
          }, function (error) {
            return _this25.handleError(error);
          });
        } //set attribute values for the product

      }, {
        key: "handleProductAttributeChange",
        value: function handleProductAttributeChange(event) {
          var _this26 = this;

          this.productAttributeValues = new Array();
          this.disableProductAttributeValue = this.selectedProductAttribute == null;

          if (this.selectedProductAttribute != null) {
            this.dataService.getAttributeValuesForProduct(this.product, this.selectedProductAttribute).subscribe(function (attributeValues) {
              var tempArray = new Array();
              attributeValues.forEach(function (attributeValue) {
                var item = {
                  label: attributeValue.description,
                  value: attributeValue
                };
                tempArray.push(item);

                if (attributeValue.isDefault) {
                  _this26.defaultProductAttributeValue = attributeValue;
                }
              });
              _this26.productAttributeValues = tempArray;
            }, function (error) {
              return _this26.handleError(error);
            });
          }
        }
      }, {
        key: "handleDefaultProductAttributeValueChange",
        value: function handleDefaultProductAttributeValueChange(event) {
          this.setdefaultProductAttributeValue();
        }
      }, {
        key: "productAttributeValuesChanged",
        value: function productAttributeValuesChanged(event) {
          this.productAttributeValues = event;

          if (event.length > 0) {
            this.defaultProductAttributeValue = event[0].value;
            this.setdefaultProductAttributeValue();
          }
        }
      }, {
        key: "clickSaveProductAttributeValues",
        value: function clickSaveProductAttributeValues() {
          var _this27 = this;

          var dataToSubmit = new Array();
          this.productAttributeValues.forEach(function (selItem) {
            return dataToSubmit.push(selItem.value);
          });
          this.dataService.setAttributeValuesForProduct(this.product, this.selectedProductAttribute, dataToSubmit).subscribe(function () {
            _this27.messageService.clear();

            _this27.productAttributeValues = new Array();
            _this27.defaultProductAttributeValue = null;
            _this27.selectedProductAttribute = null;
            _this27.disableProductAttributeValue = true;
          }, function (error) {
            return _this27.handleError(error);
          });
        }
      }, {
        key: "setdefaultProductAttributeValue",
        value: function setdefaultProductAttributeValue() {
          this.productAttributeValues.forEach(function (attributeValue) {
            attributeValue.value.isDefault = false;
          });
          this.defaultProductAttributeValue.isDefault = true;
        } //set attribute values for product options (only the options associated with the product)

      }, {
        key: "handleProductOptionForAttributeValueChange",
        value: function handleProductOptionForAttributeValueChange(event) {
          var _this28 = this;

          this.showDetail = false;
          this.productOptionAttributeList = new Array();

          if (this.selectedProductOptionForAttributeValue != null) {
            this.showDetail = true;
            this.prodOptionService.getAttributesForProductOption(this.product, this.selectedProductOptionForAttributeValue).subscribe(function (attributes) {
              _this28.selectedProductOptionAttribute = new attributeDropDown_1.AttributeDropDown();

              if (attributes.length < 1) {
                _this28.showPrductOptionAttributeValues = false;
                _this28.selectedProductOptionAttribute.label = 'No Attributes associated with Product Option';
              } else {
                _this28.showPrductOptionAttributeValues = true;
                _this28.selectedProductOptionAttribute.label = 'Select an Attribute';
              }

              _this28.productOptionAttributeList.push(_this28.selectedProductOptionAttribute);

              attributes.forEach(function (attribute) {
                var attributeDropDownItem = new attributeDropDown_1.AttributeDropDown();
                attributeDropDownItem.label = attribute.name;
                attributeDropDownItem.value = attribute;

                _this28.productOptionAttributeList.push(attributeDropDownItem);
              });
            }, function (error) {
              return _this28.handleError(error);
            });
          }
        }
      }, {
        key: "handleProductOptionAttributeChange",
        value: function handleProductOptionAttributeChange(event) {
          var _this29 = this;

          this.productOptionAttributeValues = new Array();
          this.disableProductOptionAttributeValue = this.selectedProductOptionAttribute == null;

          if (this.selectedProductOptionAttribute != null) {
            this.prodOptionService.getAttributeValuesForProductOption(this.product, this.selectedProductOptionForAttributeValue, this.selectedProductOptionAttribute).subscribe(function (poattValues) {
              var tempArray = new Array();
              poattValues.forEach(function (attributeValue) {
                var item = {
                  label: attributeValue.description,
                  value: attributeValue
                };
                tempArray.push(item);

                if (attributeValue.isDefault) {
                  _this29.defaultProductOptionAttributeValue = attributeValue;
                }
              });
              _this29.productOptionAttributeValues = tempArray;
            }, function (error) {
              return _this29.handleError(error);
            });
          }
        }
      }, {
        key: "handleDefaultProductOptionAttributeValueChange",
        value: function handleDefaultProductOptionAttributeValueChange(event) {
          this.setdefaultProductOptionAttributeValue();
        }
      }, {
        key: "productOptionAttributeValuesChanged",
        value: function productOptionAttributeValuesChanged(event) {
          this.productOptionAttributeValues = event;

          if (event.length > 0) {
            this.defaultProductOptionAttributeValue = event[0].value;
            this.setdefaultProductOptionAttributeValue();
          }
        }
      }, {
        key: "setdefaultProductOptionAttributeValue",
        value: function setdefaultProductOptionAttributeValue() {
          this.productOptionAttributeValues.forEach(function (attributeValue) {
            attributeValue.value.isDefault = false;
          });
          this.defaultProductOptionAttributeValue.isDefault = true;
        }
      }, {
        key: "clickSaveProductOptionAttributeValues",
        value: function clickSaveProductOptionAttributeValues() {
          var _this30 = this;

          var dataToSubmit = new Array();
          this.productOptionAttributeValues.forEach(function (selItem) {
            return dataToSubmit.push(selItem.value);
          });
          this.prodOptionService.setAttributeValuesForProductOption(this.product, this.selectedProductOptionForAttributeValue, this.selectedProductOptionAttribute, dataToSubmit).subscribe(function () {
            _this30.messageService.clear();

            _this30.productOptionAttributeValues = new Array();
            _this30.defaultProductOptionAttributeValue = null;
            _this30.selectedProductOptionAttribute = null;
            _this30.disableProductOptionAttributeValue = true;
          }, function (error) {
            return _this30.handleError(error);
          });
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear;
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }]);

      return ProductSetupComponent;
    }();

    exports.ProductSetupComponent = ProductSetupComponent;

    ProductSetupComponent.??fac = function ProductSetupComponent_Factory(t) {
      return new (t || ProductSetupComponent)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.ProductService), i0.????directiveInject(i3.ProductOptionService), i0.????directiveInject(i4.AttributeService));
    };

    ProductSetupComponent.??cmp = i0.????defineComponent({
      type: ProductSetupComponent,
      selectors: [["productSetup"]],
      inputs: {
        product: ["ProductData", "product"],
        changeIt: ["ChangeTrigger", "changeIt"]
      },
      features: [i0.????NgOnChangesFeature],
      decls: 23,
      vars: 18,
      consts: [[1, "ui-g"], [1, "ui-g-12", "ui-md-12"], ["legend", "Product Attribute Values", 3, "toggleable"], [1, "ui-g-4"], [3, "options", "ngModel", "ngModelChange", "onChange"], [4, "ngIf"], ["legend", "Product Option Attributes", 3, "toggleable", "collapsed"], [1, "ui-g-5"], [3, "sourceHeader", "source", "targetHeader", "target", "showSourceControls", "showTargetControls"], ["pTemplate", "item"], [1, "ui-g-12"], ["pButton", "", "type", "button", "label", "Save Attributes", 3, "disabled", "click"], ["legend", "Product Option Attribute Values", 3, "toggleable", "collapsed"], [3, "disabled", "Creator", "EnteryValues", "valuesChanged"], [1, "ui-g-3"], ["pButton", "", "type", "button", "label", "Save Values", 3, "disabled", "click"], ["class", "ui-g-12", 4, "ngIf"]],
      template: function ProductSetupComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "div", 0);
          i0.????elementStart(1, "div", 1);
          i0.????elementStart(2, "div", 0);
          i0.????elementStart(3, "p-fieldset", 2);
          i0.????elementStart(4, "div", 3);
          i0.????text(5, " Product Attribute");
          i0.????element(6, "br");
          i0.????elementStart(7, "p-dropdown", 4);
          i0.????listener("ngModelChange", function ProductSetupComponent_Template_p_dropdown_ngModelChange_7_listener($event) {
            return ctx.selectedProductAttribute = $event;
          })("onChange", function ProductSetupComponent_Template_p_dropdown_onChange_7_listener($event) {
            return ctx.handleProductAttributeChange($event);
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????template(8, ProductSetupComponent_div_8_Template, 9, 6, "div", 5);
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(9, "div", 0);
          i0.????elementStart(10, "p-fieldset", 6);
          i0.????elementStart(11, "div", 7);
          i0.????text(12, " Product Option");
          i0.????element(13, "br");
          i0.????elementStart(14, "p-dropdown", 4);
          i0.????listener("ngModelChange", function ProductSetupComponent_Template_p_dropdown_ngModelChange_14_listener($event) {
            return ctx.selectedProductOption = $event;
          })("onChange", function ProductSetupComponent_Template_p_dropdown_onChange_14_listener($event) {
            return ctx.handleProductOptionChange($event);
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(15, "div", 3);
          i0.????elementStart(16, "p-pickList", 8);
          i0.????template(17, ProductSetupComponent_ng_template_17_Template, 1, 1, "ng-template", 9);
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(18, "div", 10);
          i0.????elementStart(19, "button", 11);
          i0.????listener("click", function ProductSetupComponent_Template_button_click_19_listener() {
            return ctx.clickSaveAttributes();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(20, "div", 0);
          i0.????elementStart(21, "p-fieldset", 12);
          i0.????template(22, ProductSetupComponent_div_22_Template, 6, 3, "div", 5);
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????advance(3);
          i0.????property("toggleable", true);
          i0.????advance(4);
          i0.????property("options", ctx.productAttributeList)("ngModel", ctx.selectedProductAttribute);
          i0.????advance(1);
          i0.????property("ngIf", ctx.showPrductAttributeValues);
          i0.????advance(2);
          i0.????property("toggleable", true)("collapsed", true);
          i0.????advance(4);
          i0.????property("options", ctx.productOptionList)("ngModel", ctx.selectedProductOption);
          i0.????advance(2);
          i0.????property("sourceHeader", ctx.productOptionAttributeSourceHeading)("source", ctx.possibleAttributes)("targetHeader", ctx.productOptionAttributeTargetHeader)("target", ctx.attributes)("showSourceControls", false)("showTargetControls", false);
          i0.????advance(3);
          i0.????property("disabled", !ctx.validProductOption);
          i0.????advance(2);
          i0.????property("toggleable", true)("collapsed", true);
          i0.????advance(1);
          i0.????property("ngIf", !ctx.validProductOption);
        }
      },
      directives: [i5.Fieldset, i6.Dropdown, i7.NgControlStatus, i7.NgModel, i8.NgIf, i9.PickList, i1.PrimeTemplate, i10.ButtonDirective, i11.ListEntryComponent],
      styles: ["body[_ngcontent-%COMP%] {\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvY29tcG9uZW50cy9wcm9kdWN0U2V0dXAvcHJvZHVjdFNldHVwLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7QUFDQSIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvcHJvZHVjdFNldHVwL3Byb2R1Y3RTZXR1cC5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiYm9keSB7XHJcbn1cclxuIl19 */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductSetupComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'productSetup',
          templateUrl: './productSetup.component.html',
          styleUrls: ['./productSetup.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.ProductService
        }, {
          type: i3.ProductOptionService
        }, {
          type: i4.AttributeService
        }];
      }, {
        product: [{
          type: core_1.Input,
          args: ['ProductData']
        }],
        changeIt: [{
          type: core_1.Input,
          args: ['ChangeTrigger']
        }]
      });
    })();
    /***/

  },

  /***/
  "./src/app/components/products/products.component.ts":
  /*!***********************************************************!*\
    !*** ./src/app/components/products/products.component.ts ***!
    \***********************************************************/

  /*! no static exports found */

  /***/
  function srcAppComponentsProductsProductsComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js"); //models


    var productModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/productModel */
    "./src/commonComponents/models/products/productModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../../commonComponents/service/product.service */
    "./src/commonComponents/service/product.service.ts");

    var i3 = __webpack_require__(
    /*! ../../../commonComponents/service/productOption.service */
    "./src/commonComponents/service/productOption.service.ts");

    var i4 = __webpack_require__(
    /*! ../../../commonComponents/service/attribute.service */
    "./src/commonComponents/service/attribute.service.ts");

    var i5 = __webpack_require__(
    /*! primeng/table */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-table.js");

    var i6 = __webpack_require__(
    /*! primeng/dialog */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dialog.js");

    var i7 = __webpack_require__(
    /*! ../../../commonComponents/components/product/product.component */
    "./src/commonComponents/components/product/product.component.ts");

    var i8 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i9 = __webpack_require__(
    /*! ../productSetup/productSetup.component */
    "./src/app/components/productSetup/productSetup.component.ts");

    var i10 = __webpack_require__(
    /*! primeng/picklist */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-picklist.js");

    var i11 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function ProductsComponent_ng_template_2_Template(rf, ctx) {
      if (rf & 1) {
        var _r6 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "th");
        i0.????elementStart(2, "button", 17);
        i0.????listener("click", function ProductsComponent_ng_template_2_Template_button_click_2_listener() {
          i0.????restoreView(_r6);
          var ctx_r5 = i0.????nextContext();
          return ctx_r5.clickNewProductDialog();
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "th", 18);
        i0.????text(4, "Name");
        i0.????element(5, "p-sortIcon", 19);
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(6, "tr");
        i0.????element(7, "th");
        i0.????elementStart(8, "th");
        i0.????elementStart(9, "input", 20);
        i0.????listener("input", function ProductsComponent_ng_template_2_Template_input_input_9_listener($event) {
          i0.????restoreView(_r6);
          i0.????nextContext();

          var _r0 = i0.????reference(1);

          return _r0.filter($event.target.value, "name", "contains");
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }
    }

    function ProductsComponent_ng_template_3_Template(rf, ctx) {
      if (rf & 1) {
        var _r10 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "td");
        i0.????elementStart(2, "table");
        i0.????elementStart(3, "tr");
        i0.????elementStart(4, "td");
        i0.????elementStart(5, "button", 21);
        i0.????listener("click", function ProductsComponent_ng_template_3_Template_button_click_5_listener() {
          i0.????restoreView(_r10);
          var product_r8 = ctx.$implicit;
          var ctx_r9 = i0.????nextContext();
          return ctx_r9.clickDetailDialog(product_r8);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(6, "td");
        i0.????elementStart(7, "button", 22);
        i0.????listener("click", function ProductsComponent_ng_template_3_Template_button_click_7_listener() {
          i0.????restoreView(_r10);
          var product_r8 = ctx.$implicit;
          var ctx_r11 = i0.????nextContext();
          return ctx_r11.clickProductSetupDialog(product_r8);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(8, "td");
        i0.????text(9);
        i0.????elementEnd();
        i0.????elementStart(10, "td");
        i0.????elementStart(11, "table");
        i0.????elementStart(12, "tr");
        i0.????elementStart(13, "td");
        i0.????elementStart(14, "button", 23);
        i0.????listener("click", function ProductsComponent_ng_template_3_Template_button_click_14_listener() {
          i0.????restoreView(_r10);
          var product_r8 = ctx.$implicit;
          var ctx_r12 = i0.????nextContext();
          return ctx_r12.clickSetOptionsDialog(product_r8);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(15, "td");
        i0.????elementStart(16, "button", 24);
        i0.????listener("click", function ProductsComponent_ng_template_3_Template_button_click_16_listener() {
          i0.????restoreView(_r10);
          var product_r8 = ctx.$implicit;
          var ctx_r13 = i0.????nextContext();
          return ctx_r13.clickSetAttributessDialog(product_r8);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var product_r8 = ctx.$implicit;
        i0.????advance(9);
        i0.????textInterpolate(product_r8.name);
      }
    }

    function ProductsComponent_ng_template_16_Template(rf, ctx) {
      if (rf & 1) {
        i0.????text(0);
      }

      if (rf & 2) {
        var option_r14 = ctx.$implicit;
        i0.????textInterpolate1(" ", option_r14.name, " ");
      }
    }

    function ProductsComponent_ng_template_21_Template(rf, ctx) {
      if (rf & 1) {
        i0.????text(0);
      }

      if (rf & 2) {
        var option_r15 = ctx.$implicit;
        i0.????textInterpolate1(" ", option_r15.name, " ");
      }
    }

    var ProductsComponent = /*#__PURE__*/function () {
      function ProductsComponent(messageService, dataService, prodOptionService, attributeService) {
        var _this31 = this;

        _classCallCheck(this, ProductsComponent);

        this.messageService = messageService;
        this.dataService = dataService;
        this.prodOptionService = prodOptionService;
        this.attributeService = attributeService;
        this.trigerChange = 0;
        this.productOptionsSourceHeading = "Available Options";
        this.productOptionsTargerHeading = "Associated Options";
        this.productAttributeSourceHeading = "Available Attributes";
        this.productAttributeTargetHeader = "Associated Attributes";
        this.productData = new Array();
        this.prodOptionService.getProductOptions().subscribe(function (options) {
          _this31.allProductionOptions = options;
        });
        this.attributeService.getAttributes().subscribe(function (attributes) {
          _this31.allAttributes = attributes;
        });
      }

      _createClass(ProductsComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.loadProducts();
        }
      }, {
        key: "loadProducts",
        value: function loadProducts() {
          var _this32 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Loading Products'
          });
          this.dataService.getProducts().subscribe(function (dataSet) {
            _this32.productData = dataSet;

            _this32.messageService.clear();
          }, function (ex) {
            return _this32.handleError(ex);
          });
        }
      }, {
        key: "clickNewProductDialog",
        value: function clickNewProductDialog() {
          if (this.newProduct == null) this.newProduct = new productModel_1.ProductModel();
          this.showNewProductDialog = true;
        }
      }, {
        key: "createNewProductDialogClick",
        value: function createNewProductDialogClick() {
          var _this33 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Saving Product'
          });
          var productToUpload = this.newProduct;
          this.dataService.setProduct(productToUpload).subscribe(function () {
            return _this33.loadProducts();
          }, function (error) {
            return _this33.handleError(error);
          });
          this.showNewProductDialog = false;
        }
      }, {
        key: "clickDetailDialog",
        value: function clickDetailDialog(product) {
          this.selectedProduct = product;
          this.showProductDetailDialog = true;
        }
      }, {
        key: "saveProductDetailDialogClick",
        value: function saveProductDetailDialogClick() {
          var _this34 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Saving Product'
          });
          var productToUpload = this.selectedProduct;
          this.dataService.setProduct(productToUpload).subscribe(function () {
            _this34.messageService.clear();
          }, function (error) {
            return _this34.handleError(error);
          });
          this.showProductDetailDialog = false;
        }
      }, {
        key: "clickProductSetupDialog",
        value: function clickProductSetupDialog(product) {
          // this is a hack so ngOnChanges is fired  in the product setup component
          // and the product has not changed but any product-option relationship has
          this.trigerChange++;
          this.selectedProduct = product;
          this.showProductSetupDialog = true;
        }
      }, {
        key: "onHideProductDetails",
        value: function onHideProductDetails(events) {}
      }, {
        key: "clickSetOptionsDialog",
        value: function clickSetOptionsDialog(product) {
          var _this35 = this;

          this.prodOptionService.getOptionsForProduct(product).subscribe(function (options) {
            //the stream is a one time hit
            _this35.selectedProduct = product;
            _this35.productOptions = options;
            _this35.possibleProductionOptions = new Array();

            _this35.allProductionOptions.forEach(function (prodOption) {
              if (_this35.isProductOptionAssociated(prodOption) == false) {
                _this35.possibleProductionOptions.push(prodOption);
              }
            });

            _this35.showProductOptionsDialog = true;
          });
        }
      }, {
        key: "isProductOptionAssociated",
        value: function isProductOptionAssociated(option) {
          var returnValue = false;

          for (var sub = 0; sub < this.productOptions.length; sub++) {
            var associatedOption = this.productOptions[sub];

            if (associatedOption.id == option.id) {
              returnValue = true;
              break;
            }
          }

          return returnValue;
        }
      }, {
        key: "clickSaveProductOptions",
        value: function clickSaveProductOptions() {
          var _this36 = this;

          this.prodOptionService.setProductionOptionsForProduct(this.selectedProduct, this.productOptions).subscribe(function () {
            _this36.messageService.clear();
          }, function (error) {
            return _this36.handleError(error);
          });
          this.showProductOptionsDialog = false;
        }
      }, {
        key: "clickSetAttributessDialog",
        value: function clickSetAttributessDialog(product) {
          var _this37 = this;

          this.dataService.getAttributesForProduct(product).subscribe(function (attributes) {
            _this37.selectedProduct = product;
            _this37.attributes = attributes;
            _this37.possibleAttributes = new Array();

            _this37.allAttributes.forEach(function (att) {
              if (_this37.isProductAttributeAssociated(att) == false) {
                _this37.possibleAttributes.push(att);
              }
            });
          });
          this.showProductAttributesDialog = true;
        }
      }, {
        key: "isProductAttributeAssociated",
        value: function isProductAttributeAssociated(attribute) {
          var returnValue = false;

          for (var sub = 0; sub < this.attributes.length; sub++) {
            var associatedAttribute = this.attributes[sub];

            if (associatedAttribute.id == attribute.id) {
              returnValue = true;
              break;
            }
          }

          return returnValue;
        }
      }, {
        key: "clickSaveProductAttributes",
        value: function clickSaveProductAttributes() {
          var _this38 = this;

          this.dataService.setAttributesForProduct(this.selectedProduct, this.attributes).subscribe(function () {
            _this38.messageService.clear();
          }, function (error) {
            return _this38.handleError(error);
          });
          this.showProductAttributesDialog = false;
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear();
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }]);

      return ProductsComponent;
    }();

    exports.ProductsComponent = ProductsComponent;

    ProductsComponent.??fac = function ProductsComponent_Factory(t) {
      return new (t || ProductsComponent)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.ProductService), i0.????directiveInject(i3.ProductOptionService), i0.????directiveInject(i4.AttributeService));
    };

    ProductsComponent.??cmp = i0.????defineComponent({
      type: ProductsComponent,
      selectors: [["products"]],
      decls: 24,
      vars: 30,
      consts: [[3, "value", "rows", "paginator"], ["productTable", ""], ["pTemplate", "header"], ["pTemplate", "body"], ["header", "Create New Product", "position", "Top", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], [3, "ProductData"], ["type", "button", "pButton", "", "label", "Create Product", 3, "click"], ["header", "Product Details", "position", "Top", "minHeight", "800", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange", "onHide"], ["type", "button", "pButton", "", "label", "Save Product", 3, "click"], ["position", "Top", "modal", "true", 3, "header", "visible", "closable", "visibleChange"], [3, "ProductData", "ChangeTrigger"], ["header", "Associated Options", "position", "Top", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], [3, "sourceHeader", "source", "targetHeader", "target", "showSourceControls", "showTargetControls"], ["pTemplate", "item"], ["type", "button", "pButton", "", "label", "Save Product Options", 3, "click"], ["header", "Associated Attributes", "position", "Top", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], ["type", "button", "pButton", "", "label", "Save Product Attributes", 3, "click"], ["type", "button", "pButton", "", "label", "Add", 3, "click"], ["pSortableColumn", "name"], ["field", "name"], ["pInputText", "", "type", "text", 3, "input"], ["type", "button", "pButton", "", "icon", "fa fa-binoculars", 3, "click"], ["type", "button", "pButton", "", "icon", "fa fa-cogs", 3, "click"], ["type", "button", "pButton", "", "label", "Set Options", 3, "click"], ["type", "button", "pButton", "", "label", "Set Attributes", 3, "click"]],
      template: function ProductsComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "p-table", 0, 1);
          i0.????template(2, ProductsComponent_ng_template_2_Template, 10, 0, "ng-template", 2);
          i0.????template(3, ProductsComponent_ng_template_3_Template, 17, 1, "ng-template", 3);
          i0.????elementEnd();
          i0.????elementStart(4, "p-dialog", 4);
          i0.????listener("visibleChange", function ProductsComponent_Template_p_dialog_visibleChange_4_listener($event) {
            return ctx.showNewProductDialog = $event;
          });
          i0.????element(5, "product", 5);
          i0.????elementStart(6, "p-footer");
          i0.????elementStart(7, "button", 6);
          i0.????listener("click", function ProductsComponent_Template_button_click_7_listener() {
            return ctx.createNewProductDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(8, "p-dialog", 7);
          i0.????listener("visibleChange", function ProductsComponent_Template_p_dialog_visibleChange_8_listener($event) {
            return ctx.showProductDetailDialog = $event;
          })("onHide", function ProductsComponent_Template_p_dialog_onHide_8_listener($event) {
            return ctx.onHideProductDetails($event);
          });
          i0.????element(9, "product", 5);
          i0.????elementStart(10, "p-footer");
          i0.????elementStart(11, "button", 8);
          i0.????listener("click", function ProductsComponent_Template_button_click_11_listener() {
            return ctx.saveProductDetailDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(12, "p-dialog", 9);
          i0.????listener("visibleChange", function ProductsComponent_Template_p_dialog_visibleChange_12_listener($event) {
            return ctx.showProductSetupDialog = $event;
          });
          i0.????element(13, "productSetup", 10);
          i0.????elementEnd();
          i0.????elementStart(14, "p-dialog", 11);
          i0.????listener("visibleChange", function ProductsComponent_Template_p_dialog_visibleChange_14_listener($event) {
            return ctx.showProductOptionsDialog = $event;
          });
          i0.????elementStart(15, "p-pickList", 12);
          i0.????template(16, ProductsComponent_ng_template_16_Template, 1, 1, "ng-template", 13);
          i0.????elementEnd();
          i0.????elementStart(17, "p-footer");
          i0.????elementStart(18, "button", 14);
          i0.????listener("click", function ProductsComponent_Template_button_click_18_listener() {
            return ctx.clickSaveProductOptions();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(19, "p-dialog", 15);
          i0.????listener("visibleChange", function ProductsComponent_Template_p_dialog_visibleChange_19_listener($event) {
            return ctx.showProductAttributesDialog = $event;
          });
          i0.????elementStart(20, "p-pickList", 12);
          i0.????template(21, ProductsComponent_ng_template_21_Template, 1, 1, "ng-template", 13);
          i0.????elementEnd();
          i0.????elementStart(22, "p-footer");
          i0.????elementStart(23, "button", 16);
          i0.????listener("click", function ProductsComponent_Template_button_click_23_listener() {
            return ctx.clickSaveProductAttributes();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("value", ctx.productData)("rows", 10)("paginator", true);
          i0.????advance(4);
          i0.????property("visible", ctx.showNewProductDialog)("closable", true);
          i0.????advance(1);
          i0.????property("ProductData", ctx.newProduct);
          i0.????advance(3);
          i0.????property("visible", ctx.showProductDetailDialog)("closable", true);
          i0.????advance(1);
          i0.????property("ProductData", ctx.selectedProduct);
          i0.????advance(3);
          i0.????propertyInterpolate("header", ctx.selectedProduct != null ? ctx.selectedProduct.name + " Detail Setup" : "" + " Detail Setup");
          i0.????property("visible", ctx.showProductSetupDialog)("closable", true);
          i0.????advance(1);
          i0.????property("ProductData", ctx.selectedProduct)("ChangeTrigger", ctx.trigerChange);
          i0.????advance(1);
          i0.????property("visible", ctx.showProductOptionsDialog)("closable", true);
          i0.????advance(1);
          i0.????property("sourceHeader", ctx.productOptionsSourceHeading)("source", ctx.possibleProductionOptions)("targetHeader", ctx.productOptionsTargerHeading)("target", ctx.productOptions)("showSourceControls", false)("showTargetControls", false);
          i0.????advance(4);
          i0.????property("visible", ctx.showProductAttributesDialog)("closable", true);
          i0.????advance(1);
          i0.????property("sourceHeader", ctx.productAttributeSourceHeading)("source", ctx.possibleAttributes)("targetHeader", ctx.productAttributeTargetHeader)("target", ctx.attributes)("showSourceControls", false)("showTargetControls", false);
        }
      },
      directives: [i5.Table, i1.PrimeTemplate, i6.Dialog, i7.ProductComponent, i1.Footer, i8.ButtonDirective, i9.ProductSetupComponent, i10.PickList, i5.SortableColumn, i5.SortIcon, i11.InputText],
      styles: [".TestWidth[_ngcontent-%COMP%] {\r\n    width: 75px\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvY29tcG9uZW50cy9wcm9kdWN0cy9wcm9kdWN0cy5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0lBQ0k7QUFDSiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvcHJvZHVjdHMvcHJvZHVjdHMuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5UZXN0V2lkdGgge1xyXG4gICAgd2lkdGg6IDc1cHhcclxufSJdfQ== */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductsComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'products',
          templateUrl: './products.component.html',
          styleUrls: ['./products.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.ProductService
        }, {
          type: i3.ProductOptionService
        }, {
          type: i4.AttributeService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/models/attributeDropDown.ts":
  /*!*********************************************!*\
    !*** ./src/app/models/attributeDropDown.ts ***!
    \*********************************************/

  /*! no static exports found */

  /***/
  function srcAppModelsAttributeDropDownTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var AttributeDropDown = function AttributeDropDown() {
      _classCallCheck(this, AttributeDropDown);

      this.label = '';
      this.value = null;
    };

    exports.AttributeDropDown = AttributeDropDown;
    /***/
  },

  /***/
  "./src/app/models/productDropDown.ts":
  /*!*******************************************!*\
    !*** ./src/app/models/productDropDown.ts ***!
    \*******************************************/

  /*! no static exports found */

  /***/
  function srcAppModelsProductDropDownTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var ProductDropDown = function ProductDropDown() {
      _classCallCheck(this, ProductDropDown);

      this.label = '';
      this.value = null;
    };

    exports.ProductDropDown = ProductDropDown;
    /***/
  },

  /***/
  "./src/app/models/productOptionDropDown.ts":
  /*!*************************************************!*\
    !*** ./src/app/models/productOptionDropDown.ts ***!
    \*************************************************/

  /*! no static exports found */

  /***/
  function srcAppModelsProductOptionDropDownTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var ProductOptionDropDown = function ProductOptionDropDown() {
      _classCallCheck(this, ProductOptionDropDown);

      this.label = '';
      this.value = null;
    };

    exports.ProductOptionDropDown = ProductOptionDropDown;
    /***/
  },

  /***/
  "./src/app/views/optionPricingView.component.ts":
  /*!******************************************************!*\
    !*** ./src/app/views/optionPricingView.component.ts ***!
    \******************************************************/

  /*! no static exports found */

  /***/
  function srcAppViewsOptionPricingViewComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //*******************************************************************
    //  This is the Price Option item on the product menu
    //*******************************************************************
    //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var productOptionDropDown_1 = __webpack_require__(
    /*! ../models/productOptionDropDown */
    "./src/app/models/productOptionDropDown.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../commonComponents/service/productOption.service */
    "./src/commonComponents/service/productOption.service.ts");

    var i3 = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");

    var i4 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var i5 = __webpack_require__(
    /*! ../components/baseOptionPrices/baseOptionPrices.component */
    "./src/app/components/baseOptionPrices/baseOptionPrices.component.ts");

    var i6 = __webpack_require__(
    /*! primeng/dialog */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dialog.js");

    var i7 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i8 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i9 = __webpack_require__(
    /*! primeng/dropdown */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dropdown.js");

    function OptionPricingViewComponent_div_0_Template(rf, ctx) {
      if (rf & 1) {
        var _r2 = i0.????getCurrentView();

        i0.????elementStart(0, "div", 1);
        i0.????elementStart(1, "p-dropdown", 5);
        i0.????listener("ngModelChange", function OptionPricingViewComponent_div_0_Template_p_dropdown_ngModelChange_1_listener($event) {
          i0.????restoreView(_r2);
          var ctx_r1 = i0.????nextContext();
          return ctx_r1.selectedProductOption = $event;
        });
        i0.????elementEnd();
        i0.????element(2, "br");
        i0.????element(3, "br");
        i0.????elementStart(4, "button", 6);
        i0.????listener("click", function OptionPricingViewComponent_div_0_Template_button_click_4_listener() {
          i0.????restoreView(_r2);
          var ctx_r3 = i0.????nextContext();
          return ctx_r3.clickAddProductPricing();
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r0 = i0.????nextContext();
        i0.????advance(1);
        i0.????property("options", ctx_r0.productOptionList)("ngModel", ctx_r0.selectedProductOption);
      }
    }

    var OptionPricingViewComponent = /*#__PURE__*/function () {
      function OptionPricingViewComponent(messageService, dataService, route, router) {
        _classCallCheck(this, OptionPricingViewComponent);

        this.messageService = messageService;
        this.dataService = dataService;
        this.route = route;
        this.router = router;
        this.selectedProductOption = null;
        this.validProductOptions = false;
      }

      _createClass(OptionPricingViewComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.loadProductOptionList();
        } //user clicked add pricing button
        //setup to create new predefined product

      }, {
        key: "clickAddProductPricing",
        value: function clickAddProductPricing() {
          this.newPricingInitialPrice = 10;
          this.showCreateInitialProductOptionPricingDialog = true;
        } //user clicked create pricing
        //create a new predefined product

      }, {
        key: "createNewProductPricingDialogClick",
        value: function createNewProductPricingDialogClick() {
          var _this39 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Saving Product'
          });
          var productOption = this.selectedProductOption.value;
          this.dataService.createInitialProductPricing(productOption, this.newPricingInitialPrice).subscribe(function () {
            _this39.messageService.clear();

            _this39.loadProductOptionList();
          }, function (error) {
            return _this39.handleError(error);
          });
          this.showCreateInitialProductOptionPricingDialog = false;
        }
      }, {
        key: "loadProductOptionList",
        value: function loadProductOptionList() {
          var _this40 = this;

          this.productOptionList = new Array();
          this.dataService.getProductOptionsWithNoPrices().subscribe(function (options) {
            _this40.validProductOptions = options.length > 0;
            options.forEach(function (productOption) {
              _this40.selectedProductOption = new productOptionDropDown_1.ProductOptionDropDown();
              _this40.selectedProductOption.label = productOption.name;
              _this40.selectedProductOption.value = productOption;

              _this40.productOptionList.push(_this40.selectedProductOption);
            });
          }, function (error) {
            return _this40.handleError(error);
          });
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear();
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }]);

      return OptionPricingViewComponent;
    }();

    exports.OptionPricingViewComponent = OptionPricingViewComponent;

    OptionPricingViewComponent.??fac = function OptionPricingViewComponent_Factory(t) {
      return new (t || OptionPricingViewComponent)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.ProductOptionService), i0.????directiveInject(i3.ActivatedRoute), i0.????directiveInject(i3.Router));
    };

    OptionPricingViewComponent.??cmp = i0.????defineComponent({
      type: OptionPricingViewComponent,
      selectors: [["optionPricingView"]],
      decls: 10,
      vars: 4,
      consts: [["class", "ui-g-12", 4, "ngIf"], [1, "ui-g-12"], ["header", "Create New Pricing For Option", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], ["type", "number", "min", "0", "step", "0.01", 1, "currency", 3, "ngModel", "ngModelChange"], ["type", "button", "pButton", "", "label", "Create Pricing", 3, "click"], [3, "options", "ngModel", "ngModelChange"], ["type", "button", "pButton", "", "label", "Create Initial Pricing", 3, "click"]],
      template: function OptionPricingViewComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????template(0, OptionPricingViewComponent_div_0_Template, 5, 2, "div", 0);
          i0.????elementStart(1, "div", 1);
          i0.????element(2, "baseOptionPrices");
          i0.????elementEnd();
          i0.????elementStart(3, "p-dialog", 2);
          i0.????listener("visibleChange", function OptionPricingViewComponent_Template_p_dialog_visibleChange_3_listener($event) {
            return ctx.showCreateInitialProductOptionPricingDialog = $event;
          });
          i0.????elementStart(4, "div");
          i0.????text(5, " Initial price");
          i0.????element(6, "br");
          i0.????elementStart(7, "input", 3);
          i0.????listener("ngModelChange", function OptionPricingViewComponent_Template_input_ngModelChange_7_listener($event) {
            return ctx.newPricingInitialPrice = $event;
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(8, "p-footer");
          i0.????elementStart(9, "button", 4);
          i0.????listener("click", function OptionPricingViewComponent_Template_button_click_9_listener() {
            return ctx.createNewProductPricingDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("ngIf", ctx.validProductOptions);
          i0.????advance(3);
          i0.????property("visible", ctx.showCreateInitialProductOptionPricingDialog)("closable", true);
          i0.????advance(4);
          i0.????property("ngModel", ctx.newPricingInitialPrice);
        }
      },
      directives: [i4.NgIf, i5.BaseOptionPricesComponent, i6.Dialog, i7.NumberValueAccessor, i7.DefaultValueAccessor, i7.NgControlStatus, i7.NgModel, i1.Footer, i8.ButtonDirective, i9.Dropdown],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3ZpZXdzL29wdGlvblByaWNpbmdWaWV3LmNvbXBvbmVudC5jc3MifQ== */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(OptionPricingViewComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'optionPricingView',
          templateUrl: './optionPricingView.component.html',
          styleUrls: ['./optionPricingView.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.ProductOptionService
        }, {
          type: i3.ActivatedRoute
        }, {
          type: i3.Router
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/views/productPackageView.Component.ts":
  /*!*******************************************************!*\
    !*** ./src/app/views/productPackageView.Component.ts ***!
    \*******************************************************/

  /*! no static exports found */

  /***/
  function srcAppViewsProductPackageViewComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //*******************************************************************
    //  This is the Package Product item on the Product Menu
    //*******************************************************************
    //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var packagedProductModel_1 = __webpack_require__(
    /*! ../../commonComponents/models/products/packagedProductModel */
    "./src/commonComponents/models/products/packagedProductModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../commonComponents/service/product.service */
    "./src/commonComponents/service/product.service.ts");

    var i3 = __webpack_require__(
    /*! primeng/table */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-table.js");

    var i4 = __webpack_require__(
    /*! primeng/dialog */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dialog.js");

    var i5 = __webpack_require__(
    /*! ../components/packagedProduct/packagedProduct.component */
    "./src/app/components/packagedProduct/packagedProduct.component.ts");

    var i6 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i7 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function ProductPackageViewComponent_ng_template_2_Template(rf, ctx) {
      if (rf & 1) {
        var _r4 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "th");
        i0.????elementStart(2, "button", 9);
        i0.????listener("click", function ProductPackageViewComponent_ng_template_2_Template_button_click_2_listener() {
          i0.????restoreView(_r4);
          var ctx_r3 = i0.????nextContext();
          return ctx_r3.clickCreatePackageProduct();
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "th", 10);
        i0.????text(4, "Description");
        i0.????element(5, "p-sortIcon", 11);
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(6, "tr");
        i0.????element(7, "th");
        i0.????elementStart(8, "th");
        i0.????elementStart(9, "input", 12);
        i0.????listener("input", function ProductPackageViewComponent_ng_template_2_Template_input_input_9_listener($event) {
          i0.????restoreView(_r4);
          i0.????nextContext();

          var _r0 = i0.????reference(1);

          return _r0.filter($event.target.value, "description", "contains");
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }
    }

    function ProductPackageViewComponent_ng_template_3_Template(rf, ctx) {
      if (rf & 1) {
        var _r8 = i0.????getCurrentView();

        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "td");
        i0.????elementStart(2, "button", 13);
        i0.????listener("click", function ProductPackageViewComponent_ng_template_3_Template_button_click_2_listener() {
          i0.????restoreView(_r8);
          var packagedProduct_r6 = ctx.$implicit;
          var ctx_r7 = i0.????nextContext();
          return ctx_r7.clickEditPackagedProductDialog(packagedProduct_r6);
        });
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementStart(3, "td");
        i0.????text(4);
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var packagedProduct_r6 = ctx.$implicit;
        i0.????advance(4);
        i0.????textInterpolate(packagedProduct_r6.description);
      }
    }

    var ProductPackageViewComponent = /*#__PURE__*/function () {
      function ProductPackageViewComponent(messageService, dataService) {
        _classCallCheck(this, ProductPackageViewComponent);

        this.messageService = messageService;
        this.dataService = dataService;
      }

      _createClass(ProductPackageViewComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          this.loadPackagedProducts();
          this.showPackageEditor = false;
        } //user clicked Create Product Package

      }, {
        key: "clickCreatePackageProduct",
        value: function clickCreatePackageProduct() {
          this.selectedPackagedProduct = new packagedProductModel_1.PackagedProductModel();
          this.setEditorTabsToFirstTab();
          this.showPackageEditor = true;
        } //user clicked the edit button in the grid

      }, {
        key: "clickEditPackagedProductDialog",
        value: function clickEditPackagedProductDialog(packagedProduct) {
          this.selectedPackagedProduct = packagedProduct;
          this.setEditorTabsToFirstTab();
          this.showPackageEditor = true;
        }
      }, {
        key: "clickNext",
        value: function clickNext() {
          this.currentTab = this.currentTab === 5 ? 5 : this.currentTab + 1;
        }
      }, {
        key: "clickPrev",
        value: function clickPrev() {
          this.currentTab = this.currentTab === 0 ? 0 : this.currentTab - 1;
        }
      }, {
        key: "clickCancel",
        value: function clickCancel() {
          this.showPackageEditor = false;
        }
      }, {
        key: "tabChanged",
        value: function tabChanged(event) {
          this.currentTab = event;
        }
      }, {
        key: "setEditorTabsToFirstTab",
        value: function setEditorTabsToFirstTab() {
          this.currentTab = 0;
        }
      }, {
        key: "loadPackagedProducts",
        value: function loadPackagedProducts() {
          var _this41 = this;

          this.dataService.getPackagedProducts().subscribe(function (packagedProducts) {
            _this41.packagedProducts = packagedProducts;
          }, function (error) {
            return _this41.handleError(error);
          });
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear();
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }]);

      return ProductPackageViewComponent;
    }();

    exports.ProductPackageViewComponent = ProductPackageViewComponent;

    ProductPackageViewComponent.??fac = function ProductPackageViewComponent_Factory(t) {
      return new (t || ProductPackageViewComponent)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.ProductService));
    };

    ProductPackageViewComponent.??cmp = i0.????defineComponent({
      type: ProductPackageViewComponent,
      selectors: [["productPackageView"]],
      decls: 10,
      vars: 7,
      consts: [[3, "value", "rows", "paginator"], ["packagedProductsTable", ""], ["pTemplate", "header"], ["pTemplate", "body"], ["header", "Packaged Product", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], [3, "packagedProduct", "tabNumber", "tabChanged"], ["type", "button", "pButton", "", "label", "Cancel", 3, "click"], ["type", "button", "pButton", "", "label", "Back", 3, "click"], ["type", "button", "pButton", "", "label", "Next", 3, "click"], ["type", "button", "pButton", "", "label", "Create", 3, "click"], ["pSortableColumn", "description"], ["field", "description"], ["pInputText", "", "type", "text", 3, "input"], ["type", "button", "pButton", "", "icon", "fa fa-binoculars", 3, "click"]],
      template: function ProductPackageViewComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "p-table", 0, 1);
          i0.????template(2, ProductPackageViewComponent_ng_template_2_Template, 10, 0, "ng-template", 2);
          i0.????template(3, ProductPackageViewComponent_ng_template_3_Template, 5, 1, "ng-template", 3);
          i0.????elementEnd();
          i0.????elementStart(4, "p-dialog", 4);
          i0.????listener("visibleChange", function ProductPackageViewComponent_Template_p_dialog_visibleChange_4_listener($event) {
            return ctx.showPackageEditor = $event;
          });
          i0.????elementStart(5, "packagedProduct", 5);
          i0.????listener("tabChanged", function ProductPackageViewComponent_Template_packagedProduct_tabChanged_5_listener($event) {
            return ctx.tabChanged($event);
          });
          i0.????elementEnd();
          i0.????elementStart(6, "p-footer");
          i0.????elementStart(7, "button", 6);
          i0.????listener("click", function ProductPackageViewComponent_Template_button_click_7_listener() {
            return ctx.clickCancel();
          });
          i0.????elementEnd();
          i0.????elementStart(8, "button", 7);
          i0.????listener("click", function ProductPackageViewComponent_Template_button_click_8_listener() {
            return ctx.clickPrev();
          });
          i0.????elementEnd();
          i0.????elementStart(9, "button", 8);
          i0.????listener("click", function ProductPackageViewComponent_Template_button_click_9_listener() {
            return ctx.clickNext();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("value", ctx.packagedProducts)("rows", 10)("paginator", true);
          i0.????advance(4);
          i0.????property("visible", ctx.showPackageEditor)("closable", true);
          i0.????advance(1);
          i0.????property("packagedProduct", ctx.selectedPackagedProduct)("tabNumber", ctx.currentTab);
        }
      },
      directives: [i3.Table, i1.PrimeTemplate, i4.Dialog, i5.PackagedProduct, i1.Footer, i6.ButtonDirective, i3.SortableColumn, i3.SortIcon, i7.InputText],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3ZpZXdzL3Byb2R1Y3RQYWNrYWdlVmlldy5jb21wb25lbnQuY3NzIn0= */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductPackageViewComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'productPackageView',
          templateUrl: './productPackageView.component.html',
          styleUrls: ['./productPackageView.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.ProductService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/views/productPricingView.component.ts":
  /*!*******************************************************!*\
    !*** ./src/app/views/productPricingView.component.ts ***!
    \*******************************************************/

  /*! no static exports found */

  /***/
  function srcAppViewsProductPricingViewComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //*******************************************************************
    //  This is the Price Product item on the product menu
    //*******************************************************************
    //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var productDropDown_1 = __webpack_require__(
    /*! ../models/productDropDown */
    "./src/app/models/productDropDown.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i2 = __webpack_require__(
    /*! ../../commonComponents/service/product.service */
    "./src/commonComponents/service/product.service.ts");

    var i3 = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");

    var i4 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var i5 = __webpack_require__(
    /*! ../components/baseProductPrices/baseProductPrices.component */
    "./src/app/components/baseProductPrices/baseProductPrices.component.ts");

    var i6 = __webpack_require__(
    /*! primeng/dialog */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dialog.js");

    var i7 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i8 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i9 = __webpack_require__(
    /*! primeng/dropdown */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dropdown.js");

    function ProductPricingViewComponent_div_0_Template(rf, ctx) {
      if (rf & 1) {
        var _r2 = i0.????getCurrentView();

        i0.????elementStart(0, "div", 1);
        i0.????elementStart(1, "p-dropdown", 5);
        i0.????listener("ngModelChange", function ProductPricingViewComponent_div_0_Template_p_dropdown_ngModelChange_1_listener($event) {
          i0.????restoreView(_r2);
          var ctx_r1 = i0.????nextContext();
          return ctx_r1.selectedProduct = $event;
        });
        i0.????elementEnd();
        i0.????element(2, "br");
        i0.????element(3, "br");
        i0.????elementStart(4, "button", 6);
        i0.????listener("click", function ProductPricingViewComponent_div_0_Template_button_click_4_listener() {
          i0.????restoreView(_r2);
          var ctx_r3 = i0.????nextContext();
          return ctx_r3.clickAddProductPricing();
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r0 = i0.????nextContext();
        i0.????advance(1);
        i0.????property("options", ctx_r0.productList)("ngModel", ctx_r0.selectedProduct);
      }
    }

    var ProductPricingViewComponent = /*#__PURE__*/function () {
      function ProductPricingViewComponent(messageService, dataService, route, router) {
        _classCallCheck(this, ProductPricingViewComponent);

        this.messageService = messageService;
        this.dataService = dataService;
        this.route = route;
        this.router = router;
        this.selectedProduct = null;
        this.validProducts = false;
      }

      _createClass(ProductPricingViewComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          var _this42 = this;

          this.route.params.subscribe(function (params) {
            _this42.someParam = params['testParameter'];
          });
          this.loadProductList();
          this.showCreateInitialProductPricingDialog = false;
        } //user clicked add pricing button
        //setup to create new predefined product

      }, {
        key: "clickAddProductPricing",
        value: function clickAddProductPricing() {
          this.newPricingInitialPrice = 10;
          this.showCreateInitialProductPricingDialog = true;
        } //user clicked create pricing on initial price dialog
        //create a new predefined product

      }, {
        key: "createNewProductPricingDialogClick",
        value: function createNewProductPricingDialogClick() {
          var _this43 = this;

          this.messageService.add({
            severity: 'info',
            summary: 'System Message',
            detail: 'Saving Product'
          });
          var productToUpload = this.selectedProduct.value;
          this.dataService.createInitialProductPricing(productToUpload, this.newPricingInitialPrice).subscribe(function () {
            _this43.messageService.clear();

            _this43.loadProductList();
          }, function (error) {
            return _this43.handleError(error);
          });
          this.showCreateInitialProductPricingDialog = false;
        }
      }, {
        key: "loadProductList",
        value: function loadProductList() {
          var _this44 = this;

          this.productList = new Array();
          this.dataService.getProductsWithNoPrices().subscribe(function (products) {
            _this44.validProducts = products.length > 0;
            products.forEach(function (product) {
              _this44.selectedProduct = new productDropDown_1.ProductDropDown();
              _this44.selectedProduct.label = product.name;
              _this44.selectedProduct.value = product;

              _this44.productList.push(_this44.selectedProduct);
            });
          }, function (error) {
            return _this44.handleError(error);
          });
        }
      }, {
        key: "handleError",
        value: function handleError(errorMsg) {
          this.messageService.clear();
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMsg
          });
        }
      }]);

      return ProductPricingViewComponent;
    }();

    exports.ProductPricingViewComponent = ProductPricingViewComponent;

    ProductPricingViewComponent.??fac = function ProductPricingViewComponent_Factory(t) {
      return new (t || ProductPricingViewComponent)(i0.????directiveInject(i1.MessageService), i0.????directiveInject(i2.ProductService), i0.????directiveInject(i3.ActivatedRoute), i0.????directiveInject(i3.Router));
    };

    ProductPricingViewComponent.??cmp = i0.????defineComponent({
      type: ProductPricingViewComponent,
      selectors: [["productPricingView"]],
      decls: 10,
      vars: 4,
      consts: [["class", "ui-g-12", 4, "ngIf"], [1, "ui-g-12"], ["header", "Create New Pricing For Product", "modal", "true", "width", "800", 3, "visible", "closable", "visibleChange"], ["type", "number", "min", "0", "step", "0.01", 1, "currency", 3, "ngModel", "ngModelChange"], ["type", "button", "pButton", "", "label", "Create Pricing", 3, "click"], [3, "options", "ngModel", "ngModelChange"], ["type", "button", "pButton", "", "label", "Create Initial Pricing", 3, "click"]],
      template: function ProductPricingViewComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????template(0, ProductPricingViewComponent_div_0_Template, 5, 2, "div", 0);
          i0.????elementStart(1, "div", 1);
          i0.????element(2, "baseProductPrices");
          i0.????elementEnd();
          i0.????elementStart(3, "p-dialog", 2);
          i0.????listener("visibleChange", function ProductPricingViewComponent_Template_p_dialog_visibleChange_3_listener($event) {
            return ctx.showCreateInitialProductPricingDialog = $event;
          });
          i0.????elementStart(4, "div");
          i0.????text(5, " Initial price");
          i0.????element(6, "br");
          i0.????elementStart(7, "input", 3);
          i0.????listener("ngModelChange", function ProductPricingViewComponent_Template_input_ngModelChange_7_listener($event) {
            return ctx.newPricingInitialPrice = $event;
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementStart(8, "p-footer");
          i0.????elementStart(9, "button", 4);
          i0.????listener("click", function ProductPricingViewComponent_Template_button_click_9_listener() {
            return ctx.createNewProductPricingDialogClick();
          });
          i0.????elementEnd();
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("ngIf", ctx.validProducts);
          i0.????advance(3);
          i0.????property("visible", ctx.showCreateInitialProductPricingDialog)("closable", true);
          i0.????advance(4);
          i0.????property("ngModel", ctx.newPricingInitialPrice);
        }
      },
      directives: [i4.NgIf, i5.BaseProductPricesComponent, i6.Dialog, i7.NumberValueAccessor, i7.DefaultValueAccessor, i7.NgControlStatus, i7.NgModel, i1.Footer, i8.ButtonDirective, i9.Dropdown],
      styles: ["input.currency[_ngcontent-%COMP%] {\r\n    text-align: right;\r\n    padding-right: 15px;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvdmlld3MvcHJvZHVjdFByaWNpbmdWaWV3LmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7SUFDSSxpQkFBaUI7SUFDakIsbUJBQW1CO0FBQ3ZCIiwiZmlsZSI6InNyYy9hcHAvdmlld3MvcHJvZHVjdFByaWNpbmdWaWV3LmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyJpbnB1dC5jdXJyZW5jeSB7XHJcbiAgICB0ZXh0LWFsaWduOiByaWdodDtcclxuICAgIHBhZGRpbmctcmlnaHQ6IDE1cHg7XHJcbn1cclxuIl19 */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductPricingViewComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'productPricingView',
          templateUrl: './productPricingView.component.html',
          styleUrls: ['./productPricingView.component.css']
        }]
      }], function () {
        return [{
          type: i1.MessageService
        }, {
          type: i2.ProductService
        }, {
          type: i3.ActivatedRoute
        }, {
          type: i3.Router
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/app/views/productSetupView.component.ts":
  /*!*****************************************************!*\
    !*** ./src/app/views/productSetupView.component.ts ***!
    \*****************************************************/

  /*! no static exports found */

  /***/
  function srcAppViewsProductSetupViewComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //*******************************************************************
    //  This is Definitions item on the Product Menu
    //*******************************************************************

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! @angular/router */
    "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");

    var i2 = __webpack_require__(
    /*! primeng/tabview */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-tabview.js");

    var i3 = __webpack_require__(
    /*! ../components/products/products.component */
    "./src/app/components/products/products.component.ts");

    var i4 = __webpack_require__(
    /*! ../components/productOptions/productOptions.component */
    "./src/app/components/productOptions/productOptions.component.ts");

    var i5 = __webpack_require__(
    /*! ../components/attributes/attributes.component */
    "./src/app/components/attributes/attributes.component.ts");

    var ProductSetupViewComponent = function ProductSetupViewComponent(route, router) {
      _classCallCheck(this, ProductSetupViewComponent);

      this.route = route;
      this.router = router;
    };

    exports.ProductSetupViewComponent = ProductSetupViewComponent;

    ProductSetupViewComponent.??fac = function ProductSetupViewComponent_Factory(t) {
      return new (t || ProductSetupViewComponent)(i0.????directiveInject(i1.ActivatedRoute), i0.????directiveInject(i1.Router));
    };

    ProductSetupViewComponent.??cmp = i0.????defineComponent({
      type: ProductSetupViewComponent,
      selectors: [["productSetupView"]],
      decls: 7,
      vars: 0,
      consts: [["header", "Product Definitions"], ["header", "Option Definitions"], ["header", "Attribute Definitions"]],
      template: function ProductSetupViewComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "p-tabView");
          i0.????elementStart(1, "p-tabPanel", 0);
          i0.????element(2, "products");
          i0.????elementEnd();
          i0.????elementStart(3, "p-tabPanel", 1);
          i0.????element(4, "productOptions");
          i0.????elementEnd();
          i0.????elementStart(5, "p-tabPanel", 2);
          i0.????element(6, "attributes");
          i0.????elementEnd();
          i0.????elementEnd();
        }
      },
      directives: [i2.TabView, i2.TabPanel, i3.ProductsComponent, i4.ProductOptionsComponent, i5.AttributesComponent],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3ZpZXdzL3Byb2R1Y3RTZXR1cFZpZXcuY29tcG9uZW50LmNzcyJ9 */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductSetupViewComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'productSetupView',
          templateUrl: './productSetupView.component.html',
          styleUrls: ['./productSetupView.component.css']
        }]
      }], function () {
        return [{
          type: i1.ActivatedRoute
        }, {
          type: i1.Router
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/commonComponents/components/attribute/attribute.component.ts":
  /*!**************************************************************************!*\
    !*** ./src/commonComponents/components/attribute/attribute.component.ts ***!
    \**************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsComponentsAttributeAttributeComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js"); //Third Party
    //models


    var attributeModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/attributeModel */
    "./src/commonComponents/models/products/attributeModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var i2 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i3 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function AttributeComponent_input_3_Template(rf, ctx) {
      if (rf & 1) {
        var _r3 = i0.????getCurrentView();

        i0.????elementStart(0, "input", 3);
        i0.????listener("ngModelChange", function AttributeComponent_input_3_Template_input_ngModelChange_0_listener($event) {
          i0.????restoreView(_r3);
          var ctx_r2 = i0.????nextContext();
          return ctx_r2.data.name = $event;
        });
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r0 = i0.????nextContext();
        i0.????property("ngModel", ctx_r0.data.name);
      }
    }

    function AttributeComponent_textarea_8_Template(rf, ctx) {
      if (rf & 1) {
        var _r5 = i0.????getCurrentView();

        i0.????elementStart(0, "textarea", 4);
        i0.????listener("ngModelChange", function AttributeComponent_textarea_8_Template_textarea_ngModelChange_0_listener($event) {
          i0.????restoreView(_r5);
          var ctx_r4 = i0.????nextContext();
          return ctx_r4.data.description = $event;
        });
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r1 = i0.????nextContext();
        i0.????property("ngModel", ctx_r1.data.description);
      }
    } //services


    var AttributeComponent = /*#__PURE__*/function () {
      //vars for this component
      function AttributeComponent() {
        _classCallCheck(this, AttributeComponent);
      }

      _createClass(AttributeComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          if (this.data === null) {
            this.data = new attributeModel_1.AttributeModel();
          }
        }
      }]);

      return AttributeComponent;
    }();

    exports.AttributeComponent = AttributeComponent;

    AttributeComponent.??fac = function AttributeComponent_Factory(t) {
      return new (t || AttributeComponent)();
    };

    AttributeComponent.??cmp = i0.????defineComponent({
      type: AttributeComponent,
      selectors: [["attribute"]],
      inputs: {
        data: ["AttributeData", "data"]
      },
      decls: 9,
      vars: 2,
      consts: [[1, "ui-g"], ["type", "text", "pInputText", "", 3, "ngModel", "ngModelChange", 4, "ngIf"], ["pInputText", "", "rows", "10", "cols", "80", 3, "ngModel", "ngModelChange", 4, "ngIf"], ["type", "text", "pInputText", "", 3, "ngModel", "ngModelChange"], ["pInputText", "", "rows", "10", "cols", "80", 3, "ngModel", "ngModelChange"]],
      template: function AttributeComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "div", 0);
          i0.????text(1, " Name");
          i0.????element(2, "br");
          i0.????template(3, AttributeComponent_input_3_Template, 1, 1, "input", 1);
          i0.????elementEnd();
          i0.????element(4, "br");
          i0.????elementStart(5, "div", 0);
          i0.????text(6, " Description");
          i0.????element(7, "br");
          i0.????template(8, AttributeComponent_textarea_8_Template, 1, 1, "textarea", 2);
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????advance(3);
          i0.????property("ngIf", ctx.data);
          i0.????advance(5);
          i0.????property("ngIf", ctx.data);
        }
      },
      directives: [i1.NgIf, i2.DefaultValueAccessor, i3.InputText, i2.NgControlStatus, i2.NgModel],
      styles: ["body[_ngcontent-%COMP%] {\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9jb21tb25Db21wb25lbnRzL2NvbXBvbmVudHMvYXR0cmlidXRlL2F0dHJpYnV0ZS5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0FBQ0EiLCJmaWxlIjoic3JjL2NvbW1vbkNvbXBvbmVudHMvY29tcG9uZW50cy9hdHRyaWJ1dGUvYXR0cmlidXRlLmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyJib2R5IHtcclxufVxyXG4iXX0= */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(AttributeComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'attribute',
          templateUrl: './attribute.component.html',
          styleUrls: ['./attribute.component.css']
        }]
      }], function () {
        return [];
      }, {
        data: [{
          type: core_1.Input,
          args: ['AttributeData']
        }]
      });
    })();
    /***/

  },

  /***/
  "./src/commonComponents/components/listEntry/listEntry.component.ts":
  /*!**************************************************************************!*\
    !*** ./src/commonComponents/components/listEntry/listEntry.component.ts ***!
    \**************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsComponentsListEntryListEntryComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/fieldset */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-fieldset.js");

    var i2 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i3 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    var i4 = __webpack_require__(
    /*! primeng/button */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-button.js");

    var i5 = __webpack_require__(
    /*! primeng/listbox */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-listbox.js");

    var ListEntryComponent = /*#__PURE__*/function () {
      function ListEntryComponent() {
        _classCallCheck(this, ListEntryComponent);

        this.valuesChanged = new core_1.EventEmitter();

        if (this.enteryValues == null) {
          this.enteryValues = new Array();
        }
      }

      _createClass(ListEntryComponent, [{
        key: "ngOnChanges",
        value: function ngOnChanges(changes) {
          console.info("got into ng on changes");
        }
      }, {
        key: "clickAddToList",
        value: function clickAddToList() {
          var _this45 = this;

          var found = false;
          this.enteryValues.forEach(function (x) {
            if (x.label === _this45.newDescription) {
              found = true;
              return;
            }
          });

          if (!found) {
            var newValueToStore = this.valueCreator.createValueObject(this.newValue, this.newDescription);
            var item = {
              label: this.newDescription,
              value: newValueToStore
            };
            var tempArray = new Array();
            this.enteryValues.forEach(function (x) {
              return tempArray.push(x);
            });
            tempArray.push(item);
            this.enteryValues = tempArray;
            this.valuesChanged.emit(this.enteryValues);
          }

          this.newValue = "";
          this.newDescription = "";
        }
      }, {
        key: "clickRemoveFromList",
        value: function clickRemoveFromList() {
          var _this46 = this;

          var tempArray = new Array();
          this.enteryValues.forEach(function (x) {
            if (x.value != _this46.selectedValue) {
              tempArray.push(x);
            }
          });
          this.enteryValues = new Array();
          tempArray.forEach(function (x) {
            _this46.enteryValues.push(x);
          });
          this.selectedValue = null;
          this.valuesChanged.emit(this.enteryValues);
        }
      }]);

      return ListEntryComponent;
    }();

    exports.ListEntryComponent = ListEntryComponent;

    ListEntryComponent.??fac = function ListEntryComponent_Factory(t) {
      return new (t || ListEntryComponent)();
    };

    ListEntryComponent.??cmp = i0.????defineComponent({
      type: ListEntryComponent,
      selectors: [["listEntry"]],
      inputs: {
        valueCreator: ["Creator", "valueCreator"],
        enteryValues: ["EnteryValues", "enteryValues"],
        enabled: ["disabled", "enabled"]
      },
      outputs: {
        valuesChanged: "valuesChanged"
      },
      features: [i0.????NgOnChangesFeature],
      decls: 15,
      vars: 7,
      consts: [["legend", "Attribute Values", 3, "toggleable"], ["for", "value"], ["id", "value", "type", "number", "pInputText", "", "min", "0", "step", "1", 3, "ngModel", "ngModelChange"], ["for", "descr"], ["id", "descr", "type", "text", "pInputText", "", 3, "ngModel", "ngModelChange"], ["pButton", "", "label", "Add To List", 3, "disabled", "click"], [3, "options", "ngModel", "ngModelChange"], ["pButton", "", "label", "Remove From List", 3, "disabled", "click"]],
      template: function ListEntryComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "p-fieldset", 0);
          i0.????elementStart(1, "label", 1);
          i0.????text(2, "Value");
          i0.????elementEnd();
          i0.????elementStart(3, "input", 2);
          i0.????listener("ngModelChange", function ListEntryComponent_Template_input_ngModelChange_3_listener($event) {
            return ctx.newValue = $event;
          });
          i0.????elementEnd();
          i0.????elementStart(4, "label", 3);
          i0.????text(5, "Value Description");
          i0.????elementEnd();
          i0.????elementStart(6, "input", 4);
          i0.????listener("ngModelChange", function ListEntryComponent_Template_input_ngModelChange_6_listener($event) {
            return ctx.newDescription = $event;
          });
          i0.????elementEnd();
          i0.????element(7, "br");
          i0.????element(8, "br");
          i0.????elementStart(9, "button", 5);
          i0.????listener("click", function ListEntryComponent_Template_button_click_9_listener() {
            return ctx.clickAddToList();
          });
          i0.????elementEnd();
          i0.????element(10, "br");
          i0.????element(11, "br");
          i0.????elementStart(12, "p-listbox", 6);
          i0.????listener("ngModelChange", function ListEntryComponent_Template_p_listbox_ngModelChange_12_listener($event) {
            return ctx.selectedValue = $event;
          });
          i0.????elementEnd();
          i0.????element(13, "br");
          i0.????elementStart(14, "button", 7);
          i0.????listener("click", function ListEntryComponent_Template_button_click_14_listener() {
            return ctx.clickRemoveFromList();
          });
          i0.????elementEnd();
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("toggleable", false);
          i0.????advance(3);
          i0.????property("ngModel", ctx.newValue);
          i0.????advance(3);
          i0.????property("ngModel", ctx.newDescription);
          i0.????advance(3);
          i0.????property("disabled", ctx.enabled);
          i0.????advance(3);
          i0.????property("options", ctx.enteryValues)("ngModel", ctx.selectedValue);
          i0.????advance(2);
          i0.????property("disabled", ctx.enabled);
        }
      },
      directives: [i1.Fieldset, i2.NumberValueAccessor, i2.DefaultValueAccessor, i3.InputText, i2.NgControlStatus, i2.NgModel, i4.ButtonDirective, i5.Listbox],
      styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvY29tbW9uQ29tcG9uZW50cy9jb21wb25lbnRzL2xpc3RFbnRyeS9saXN0RW50cnkuY29tcG9uZW50LmNzcyJ9 */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ListEntryComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'listEntry',
          templateUrl: './listEntry.component.html',
          styleUrls: ['./listEntry.component.css']
        }]
      }], function () {
        return [];
      }, {
        valueCreator: [{
          type: core_1.Input,
          args: ['Creator']
        }],
        enteryValues: [{
          type: core_1.Input,
          args: ['EnteryValues']
        }],
        enabled: [{
          type: core_1.Input,
          args: ['disabled']
        }],
        valuesChanged: [{
          type: core_1.Output
        }]
      });
    })();
    /***/

  },

  /***/
  "./src/commonComponents/components/product/product.component.ts":
  /*!**********************************************************************!*\
    !*** ./src/commonComponents/components/product/product.component.ts ***!
    \**********************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsComponentsProductProductComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js"); //Third Party
    //models


    var productModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/productModel */
    "./src/commonComponents/models/products/productModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var i2 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i3 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function ProductComponent_input_3_Template(rf, ctx) {
      if (rf & 1) {
        var _r3 = i0.????getCurrentView();

        i0.????elementStart(0, "input", 3);
        i0.????listener("ngModelChange", function ProductComponent_input_3_Template_input_ngModelChange_0_listener($event) {
          i0.????restoreView(_r3);
          var ctx_r2 = i0.????nextContext();
          return ctx_r2.data.name = $event;
        });
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r0 = i0.????nextContext();
        i0.????property("ngModel", ctx_r0.data.name);
      }
    }

    function ProductComponent_textarea_8_Template(rf, ctx) {
      if (rf & 1) {
        var _r5 = i0.????getCurrentView();

        i0.????elementStart(0, "textarea", 4);
        i0.????listener("ngModelChange", function ProductComponent_textarea_8_Template_textarea_ngModelChange_0_listener($event) {
          i0.????restoreView(_r5);
          var ctx_r4 = i0.????nextContext();
          return ctx_r4.data.description = $event;
        });
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r1 = i0.????nextContext();
        i0.????property("ngModel", ctx_r1.data.description);
      }
    } //services


    var ProductComponent = /*#__PURE__*/function () {
      //vars for this component
      function ProductComponent() {
        _classCallCheck(this, ProductComponent);
      }

      _createClass(ProductComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          if (this.data === null) {
            this.data = new productModel_1.ProductModel();
          }
        }
      }]);

      return ProductComponent;
    }();

    exports.ProductComponent = ProductComponent;

    ProductComponent.??fac = function ProductComponent_Factory(t) {
      return new (t || ProductComponent)();
    };

    ProductComponent.??cmp = i0.????defineComponent({
      type: ProductComponent,
      selectors: [["product"]],
      inputs: {
        data: ["ProductData", "data"]
      },
      decls: 9,
      vars: 2,
      consts: [[1, "ui-g"], ["type", "text", "pInputText", "", 3, "ngModel", "ngModelChange", 4, "ngIf"], ["pInputText", "", "rows", "10", "cols", "80", 3, "ngModel", "ngModelChange", 4, "ngIf"], ["type", "text", "pInputText", "", 3, "ngModel", "ngModelChange"], ["pInputText", "", "rows", "10", "cols", "80", 3, "ngModel", "ngModelChange"]],
      template: function ProductComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "div", 0);
          i0.????text(1, " Name");
          i0.????element(2, "br");
          i0.????template(3, ProductComponent_input_3_Template, 1, 1, "input", 1);
          i0.????elementEnd();
          i0.????element(4, "br");
          i0.????elementStart(5, "div", 0);
          i0.????text(6, " Description");
          i0.????element(7, "br");
          i0.????template(8, ProductComponent_textarea_8_Template, 1, 1, "textarea", 2);
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????advance(3);
          i0.????property("ngIf", ctx.data);
          i0.????advance(5);
          i0.????property("ngIf", ctx.data);
        }
      },
      directives: [i1.NgIf, i2.DefaultValueAccessor, i3.InputText, i2.NgControlStatus, i2.NgModel],
      styles: ["body[_ngcontent-%COMP%] {\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9jb21tb25Db21wb25lbnRzL2NvbXBvbmVudHMvcHJvZHVjdC9wcm9kdWN0LmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7QUFDQSIsImZpbGUiOiJzcmMvY29tbW9uQ29tcG9uZW50cy9jb21wb25lbnRzL3Byb2R1Y3QvcHJvZHVjdC5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiYm9keSB7XHJcbn1cclxuIl19 */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'product',
          templateUrl: './product.component.html',
          styleUrls: ['./product.component.css']
        }]
      }], function () {
        return [];
      }, {
        data: [{
          type: core_1.Input,
          args: ['ProductData']
        }]
      });
    })();
    /***/

  },

  /***/
  "./src/commonComponents/components/productOption/productOption.component.ts":
  /*!**********************************************************************************!*\
    !*** ./src/commonComponents/components/productOption/productOption.component.ts ***!
    \**********************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsComponentsProductOptionProductOptionComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js"); //Third Party
    //models


    var productOptionModel_1 = __webpack_require__(
    /*! ../../../commonComponents/models/products/productOptionModel */
    "./src/commonComponents/models/products/productOptionModel.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var i2 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i3 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    function ProductOptionComponent_input_3_Template(rf, ctx) {
      if (rf & 1) {
        var _r3 = i0.????getCurrentView();

        i0.????elementStart(0, "input", 3);
        i0.????listener("ngModelChange", function ProductOptionComponent_input_3_Template_input_ngModelChange_0_listener($event) {
          i0.????restoreView(_r3);
          var ctx_r2 = i0.????nextContext();
          return ctx_r2.data.name = $event;
        });
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r0 = i0.????nextContext();
        i0.????property("ngModel", ctx_r0.data.name);
      }
    }

    function ProductOptionComponent_textarea_8_Template(rf, ctx) {
      if (rf & 1) {
        var _r5 = i0.????getCurrentView();

        i0.????elementStart(0, "textarea", 4);
        i0.????listener("ngModelChange", function ProductOptionComponent_textarea_8_Template_textarea_ngModelChange_0_listener($event) {
          i0.????restoreView(_r5);
          var ctx_r4 = i0.????nextContext();
          return ctx_r4.data.description = $event;
        });
        i0.????elementEnd();
      }

      if (rf & 2) {
        var ctx_r1 = i0.????nextContext();
        i0.????property("ngModel", ctx_r1.data.description);
      }
    } //services


    var ProductOptionComponent = /*#__PURE__*/function () {
      //vars for this component
      function ProductOptionComponent() {
        _classCallCheck(this, ProductOptionComponent);
      }

      _createClass(ProductOptionComponent, [{
        key: "ngOnInit",
        value: function ngOnInit() {
          if (this.data === null) {
            this.data = new productOptionModel_1.ProductOptionModel();
          }
        }
      }]);

      return ProductOptionComponent;
    }();

    exports.ProductOptionComponent = ProductOptionComponent;

    ProductOptionComponent.??fac = function ProductOptionComponent_Factory(t) {
      return new (t || ProductOptionComponent)();
    };

    ProductOptionComponent.??cmp = i0.????defineComponent({
      type: ProductOptionComponent,
      selectors: [["productOption"]],
      inputs: {
        data: ["ProductOptionData", "data"]
      },
      decls: 9,
      vars: 2,
      consts: [[1, "ui-g"], ["type", "text", "pInputText", "", 3, "ngModel", "ngModelChange", 4, "ngIf"], ["pInputText", "", "rows", "10", "cols", "80", 3, "ngModel", "ngModelChange", 4, "ngIf"], ["type", "text", "pInputText", "", 3, "ngModel", "ngModelChange"], ["pInputText", "", "rows", "10", "cols", "80", 3, "ngModel", "ngModelChange"]],
      template: function ProductOptionComponent_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "div", 0);
          i0.????text(1, " Name");
          i0.????element(2, "br");
          i0.????template(3, ProductOptionComponent_input_3_Template, 1, 1, "input", 1);
          i0.????elementEnd();
          i0.????element(4, "br");
          i0.????elementStart(5, "div", 0);
          i0.????text(6, " Description");
          i0.????element(7, "br");
          i0.????template(8, ProductOptionComponent_textarea_8_Template, 1, 1, "textarea", 2);
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????advance(3);
          i0.????property("ngIf", ctx.data);
          i0.????advance(5);
          i0.????property("ngIf", ctx.data);
        }
      },
      directives: [i1.NgIf, i2.DefaultValueAccessor, i3.InputText, i2.NgControlStatus, i2.NgModel],
      styles: ["body[_ngcontent-%COMP%] {\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9jb21tb25Db21wb25lbnRzL2NvbXBvbmVudHMvcHJvZHVjdE9wdGlvbi9wcm9kdWN0T3B0aW9uLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7QUFDQSIsImZpbGUiOiJzcmMvY29tbW9uQ29tcG9uZW50cy9jb21wb25lbnRzL3Byb2R1Y3RPcHRpb24vcHJvZHVjdE9wdGlvbi5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiYm9keSB7XHJcbn1cclxuIl19 */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductOptionComponent, [{
        type: core_1.Component,
        args: [{
          selector: 'productOption',
          templateUrl: './productOption.component.html',
          styleUrls: ['./productOption.component.css']
        }]
      }], function () {
        return [];
      }, {
        data: [{
          type: core_1.Input,
          args: ['ProductOptionData']
        }]
      });
    })();
    /***/

  },

  /***/
  "./src/commonComponents/components/propertyBag/propertyBag.component.ts":
  /*!******************************************************************************!*\
    !*** ./src/commonComponents/components/propertyBag/propertyBag.component.ts ***!
    \******************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsComponentsPropertyBagPropertyBagComponentTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); //framework

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var forms_1 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var valueAccessorBase_1 = __webpack_require__(
    /*! ../../helpers/valueAccessorBase */
    "./src/commonComponents/helpers/valueAccessorBase.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! primeng/table */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-table.js");

    var i2 = __webpack_require__(
    /*! primeng/api */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-api.js");

    var i3 = __webpack_require__(
    /*! @angular/common */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");

    var i4 = __webpack_require__(
    /*! @angular/forms */
    "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");

    var i5 = __webpack_require__(
    /*! primeng/inputtext */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-inputtext.js");

    var i6 = __webpack_require__(
    /*! primeng/dropdown */
    "./node_modules/primeng/__ivy_ngcc__/fesm2015/primeng-dropdown.js");

    function PropertyBag_ng_template_1_Template(rf, ctx) {
      if (rf & 1) {
        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "th");
        i0.????text(2, "Descriptor");
        i0.????elementEnd();
        i0.????elementStart(3, "th");
        i0.????text(4, "Setting");
        i0.????elementEnd();
        i0.????elementEnd();
      }
    }

    function PropertyBag_ng_template_2_ng_template_5_Template(rf, ctx) {
      if (rf & 1) {
        i0.????elementStart(0, "span");
        i0.????text(1);
        i0.????elementEnd();
      }

      if (rf & 2) {
        var property_r2 = i0.????nextContext().$implicit;
        i0.????advance(1);
        i0.????textInterpolate(property_r2.possibleValues == null ? property_r2.enteredValue == null ? "" : property_r2.enteredValue : property_r2.selectedValue == null ? "" : property_r2.selectedValue.label);
      }
    }

    function PropertyBag_ng_template_2_ng_template_6_span_0_Template(rf, ctx) {
      if (rf & 1) {
        var _r10 = i0.????getCurrentView();

        i0.????elementStart(0, "span");
        i0.????elementStart(1, "input", 7);
        i0.????listener("ngModelChange", function PropertyBag_ng_template_2_ng_template_6_span_0_Template_input_ngModelChange_1_listener($event) {
          i0.????restoreView(_r10);
          var property_r2 = i0.????nextContext(2).$implicit;
          return property_r2.enteredValue = $event;
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var property_r2 = i0.????nextContext(2).$implicit;
        i0.????advance(1);
        i0.????property("ngModel", property_r2.enteredValue);
      }
    }

    function PropertyBag_ng_template_2_ng_template_6_span_1_Template(rf, ctx) {
      if (rf & 1) {
        var _r14 = i0.????getCurrentView();

        i0.????elementStart(0, "span");
        i0.????elementStart(1, "p-dropdown", 8);
        i0.????listener("ngModelChange", function PropertyBag_ng_template_2_ng_template_6_span_1_Template_p_dropdown_ngModelChange_1_listener($event) {
          i0.????restoreView(_r14);
          var property_r2 = i0.????nextContext(2).$implicit;
          return property_r2.selectedValue = $event;
        });
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var property_r2 = i0.????nextContext(2).$implicit;
        i0.????advance(1);
        i0.????property("options", property_r2.possibleValues)("ngModel", property_r2.selectedValue);
      }
    }

    function PropertyBag_ng_template_2_ng_template_6_Template(rf, ctx) {
      if (rf & 1) {
        i0.????template(0, PropertyBag_ng_template_2_ng_template_6_span_0_Template, 2, 1, "span", 6);
        i0.????template(1, PropertyBag_ng_template_2_ng_template_6_span_1_Template, 2, 2, "span", 6);
      }

      if (rf & 2) {
        var property_r2 = i0.????nextContext().$implicit;
        i0.????property("ngIf", property_r2.possibleValues == null);
        i0.????advance(1);
        i0.????property("ngIf", property_r2.possibleValues != null);
      }
    }

    function PropertyBag_ng_template_2_Template(rf, ctx) {
      if (rf & 1) {
        i0.????elementStart(0, "tr");
        i0.????elementStart(1, "td");
        i0.????text(2);
        i0.????elementEnd();
        i0.????elementStart(3, "td", 3);
        i0.????elementStart(4, "p-cellEditor");
        i0.????template(5, PropertyBag_ng_template_2_ng_template_5_Template, 2, 1, "ng-template", 4);
        i0.????template(6, PropertyBag_ng_template_2_ng_template_6_Template, 2, 2, "ng-template", 5);
        i0.????elementEnd();
        i0.????elementEnd();
        i0.????elementEnd();
      }

      if (rf & 2) {
        var property_r2 = ctx.$implicit;
        i0.????advance(2);
        i0.????textInterpolate(property_r2.name);
      }
    }

    var PropertyBag = /*#__PURE__*/function (_valueAccessorBase_1$) {
      _inherits(PropertyBag, _valueAccessorBase_1$);

      var _super = _createSuper(PropertyBag);

      function PropertyBag() {
        _classCallCheck(this, PropertyBag);

        return _super.call(this);
      }

      return PropertyBag;
    }(valueAccessorBase_1.ValueAccessorBase);

    exports.PropertyBag = PropertyBag;

    PropertyBag.??fac = function PropertyBag_Factory(t) {
      return new (t || PropertyBag)();
    };

    PropertyBag.??cmp = i0.????defineComponent({
      type: PropertyBag,
      selectors: [["propertyBag"]],
      features: [i0.????ProvidersFeature([{
        provide: forms_1.NG_VALUE_ACCESSOR,
        useExisting: core_1.forwardRef(function () {
          return PropertyBag;
        }),
        multi: true
      }]), i0.????InheritDefinitionFeature],
      decls: 3,
      vars: 3,
      consts: [[3, "value", "rows", "paginator"], ["pTemplate", "header"], ["pTemplate", "body"], ["pEditableColumn", ""], ["pTemplate", "output"], ["pTemplate", "input"], [4, "ngIf"], ["type", "text", "pInputText", "", 3, "ngModel", "ngModelChange"], [3, "options", "ngModel", "ngModelChange"]],
      template: function PropertyBag_Template(rf, ctx) {
        if (rf & 1) {
          i0.????elementStart(0, "p-table", 0);
          i0.????template(1, PropertyBag_ng_template_1_Template, 5, 0, "ng-template", 1);
          i0.????template(2, PropertyBag_ng_template_2_Template, 7, 1, "ng-template", 2);
          i0.????elementEnd();
        }

        if (rf & 2) {
          i0.????property("value", ctx.value)("rows", 5)("paginator", true);
        }
      },
      directives: [i1.Table, i2.PrimeTemplate, i1.EditableColumn, i1.CellEditor, i3.NgIf, i4.DefaultValueAccessor, i5.InputText, i4.NgControlStatus, i4.NgModel, i6.Dropdown],
      styles: [".dropDownCol[_ngcontent-%COMP%]{\r\n    overflow:visible;\r\n    width:350px !important;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9jb21tb25Db21wb25lbnRzL2NvbXBvbmVudHMvcHJvcGVydHlCYWcvcHJvcGVydHlCYWcuY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtJQUNJLGdCQUFnQjtJQUNoQixzQkFBc0I7QUFDMUIiLCJmaWxlIjoic3JjL2NvbW1vbkNvbXBvbmVudHMvY29tcG9uZW50cy9wcm9wZXJ0eUJhZy9wcm9wZXJ0eUJhZy5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmRyb3BEb3duQ29se1xyXG4gICAgb3ZlcmZsb3c6dmlzaWJsZTtcclxuICAgIHdpZHRoOjM1MHB4ICFpbXBvcnRhbnQ7XHJcbn0iXX0= */"]
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(PropertyBag, [{
        type: core_1.Component,
        args: [{
          selector: 'propertyBag',
          templateUrl: './propertyBag.component.html',
          styleUrls: ['./propertyBag.component.css'],
          providers: [{
            provide: forms_1.NG_VALUE_ACCESSOR,
            useExisting: core_1.forwardRef(function () {
              return PropertyBag;
            }),
            multi: true
          }]
        }]
      }], function () {
        return [];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/commonComponents/helpers/HttpErrorHandler.ts":
  /*!**********************************************************!*\
    !*** ./src/commonComponents/helpers/HttpErrorHandler.ts ***!
    \**********************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsHelpersHttpErrorHandlerTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var http_1 = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var rxjs_1 = __webpack_require__(
    /*! rxjs */
    "./node_modules/rxjs/_esm2015/index.js");

    var HttpErrorHandler = /*#__PURE__*/function () {
      function HttpErrorHandler() {
        _classCallCheck(this, HttpErrorHandler);
      }

      _createClass(HttpErrorHandler, null, [{
        key: "errorHandler",
        value: function errorHandler(error) {
          var errMsg;
          var systemErrorMessage;

          if (error instanceof http_1.HttpErrorResponse) {
            systemErrorMessage = error.error;
            errMsg = "".concat(systemErrorMessage.exceptionType, " - ").concat(systemErrorMessage.message || '', " URL Error Happened At ").concat(error.url);
          } else {
            errMsg = error.message ? error.message : error.toString();
          }

          console.error(errMsg);
          return rxjs_1.throwError(systemErrorMessage ? systemErrorMessage.message : errMsg);
        }
      }]);

      return HttpErrorHandler;
    }();

    exports.HttpErrorHandler = HttpErrorHandler;
    /***/
  },

  /***/
  "./src/commonComponents/helpers/productAttributeValueCreator.ts":
  /*!**********************************************************************!*\
    !*** ./src/commonComponents/helpers/productAttributeValueCreator.ts ***!
    \**********************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsHelpersProductAttributeValueCreatorTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productAttributeValueModel_1 = __webpack_require__(
    /*! ../models/products/productAttributeValueModel */
    "./src/commonComponents/models/products/productAttributeValueModel.ts");

    var ProductAttributeValueCreator = /*#__PURE__*/function () {
      function ProductAttributeValueCreator() {
        _classCallCheck(this, ProductAttributeValueCreator);
      }

      _createClass(ProductAttributeValueCreator, [{
        key: "createValueObject",
        value: function createValueObject(value, desc) {
          var returnValue = new productAttributeValueModel_1.ProductAttributeValueModel();
          returnValue.id = '';
          returnValue.valueName = value;
          returnValue.description = desc;
          return returnValue;
        }
      }]);

      return ProductAttributeValueCreator;
    }();

    exports.ProductAttributeValueCreator = ProductAttributeValueCreator;
    /***/
  },

  /***/
  "./src/commonComponents/helpers/productOptionAttributeValueCreator.ts":
  /*!****************************************************************************!*\
    !*** ./src/commonComponents/helpers/productOptionAttributeValueCreator.ts ***!
    \****************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsHelpersProductOptionAttributeValueCreatorTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productOptionAttributeValueModel_1 = __webpack_require__(
    /*! ../models/products/productOptionAttributeValueModel */
    "./src/commonComponents/models/products/productOptionAttributeValueModel.ts");

    var ProductOptionAttributeValueCreator = /*#__PURE__*/function () {
      function ProductOptionAttributeValueCreator() {
        _classCallCheck(this, ProductOptionAttributeValueCreator);
      }

      _createClass(ProductOptionAttributeValueCreator, [{
        key: "createValueObject",
        value: function createValueObject(value, desc) {
          var returnValue = new productOptionAttributeValueModel_1.ProductOptionAttributeValueModel();
          returnValue.id = '';
          returnValue.valueName = value;
          returnValue.description = desc;
          return returnValue;
        }
      }]);

      return ProductOptionAttributeValueCreator;
    }();

    exports.ProductOptionAttributeValueCreator = ProductOptionAttributeValueCreator;
    /***/
  },

  /***/
  "./src/commonComponents/helpers/valueAccessorBase.ts":
  /*!***********************************************************!*\
    !*** ./src/commonComponents/helpers/valueAccessorBase.ts ***!
    \***********************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsHelpersValueAccessorBaseTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var ValueAccessorBase = /*#__PURE__*/function () {
      function ValueAccessorBase() {
        _classCallCheck(this, ValueAccessorBase);

        this.changed = new Array();
        this.touched = new Array();
      }

      _createClass(ValueAccessorBase, [{
        key: "touch",
        value: function touch() {
          this.touched.forEach(function (f) {
            return f();
          });
        }
      }, {
        key: "writeValue",
        value: function writeValue(value) {
          this.innerValue = value;
        }
      }, {
        key: "registerOnChange",
        value: function registerOnChange(fn) {
          this.changed.push(fn);
        }
      }, {
        key: "registerOnTouched",
        value: function registerOnTouched(fn) {
          this.touched.push(fn);
        }
      }, {
        key: "value",
        get: function get() {
          return this.innerValue;
        },
        set: function set(value) {
          if (this.innerValue !== value) {
            this.innerValue = value;
            this.changed.forEach(function (f) {
              return f(value);
            });
          }
        }
      }]);

      return ValueAccessorBase;
    }();

    exports.ValueAccessorBase = ValueAccessorBase;
    /***/
  },

  /***/
  "./src/commonComponents/models/ServiceLocations.ts":
  /*!*********************************************************!*\
    !*** ./src/commonComponents/models/ServiceLocations.ts ***!
    \*********************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsServiceLocationsTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var ServiceLocations = function ServiceLocations() {
      _classCallCheck(this, ServiceLocations);
    };

    exports.ServiceLocations = ServiceLocations;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/attributeModel.ts":
  /*!****************************************************************!*\
    !*** ./src/commonComponents/models/products/attributeModel.ts ***!
    \****************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsAttributeModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); // ReSharper disable once WrongRequireRelativePath
    // ReSharper disable once StringLiteralWrongQuotes

    var AttributeModel = function AttributeModel() {
      _classCallCheck(this, AttributeModel);

      this.id = '';
      this.name = '';
      this.description = '';
    };

    exports.AttributeModel = AttributeModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/optionPricingModel.ts":
  /*!********************************************************************!*\
    !*** ./src/commonComponents/models/products/optionPricingModel.ts ***!
    \********************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsOptionPricingModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var OptionPricingModel = function OptionPricingModel() {
      _classCallCheck(this, OptionPricingModel);
    };

    exports.OptionPricingModel = OptionPricingModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/packagedProductDetailModel.ts":
  /*!****************************************************************************!*\
    !*** ./src/commonComponents/models/products/packagedProductDetailModel.ts ***!
    \****************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsPackagedProductDetailModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var PackagedProductDetailModel = function PackagedProductDetailModel() {
      _classCallCheck(this, PackagedProductDetailModel);
    };

    exports.PackagedProductDetailModel = PackagedProductDetailModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/packagedProductModel.ts":
  /*!**********************************************************************!*\
    !*** ./src/commonComponents/models/products/packagedProductModel.ts ***!
    \**********************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsPackagedProductModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var PackagedProductModel = function PackagedProductModel() {
      _classCallCheck(this, PackagedProductModel);
    };

    exports.PackagedProductModel = PackagedProductModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/packagedProductOptionDetailModel.ts":
  /*!**********************************************************************************!*\
    !*** ./src/commonComponents/models/products/packagedProductOptionDetailModel.ts ***!
    \**********************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsPackagedProductOptionDetailModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var PackagedProductOptionDetailModel = function PackagedProductOptionDetailModel() {
      _classCallCheck(this, PackagedProductOptionDetailModel);
    };

    exports.PackagedProductOptionDetailModel = PackagedProductOptionDetailModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/packagedProductOptionModel.ts":
  /*!****************************************************************************!*\
    !*** ./src/commonComponents/models/products/packagedProductOptionModel.ts ***!
    \****************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsPackagedProductOptionModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var PackagedProductOptionModel = function PackagedProductOptionModel() {
      _classCallCheck(this, PackagedProductOptionModel);
    };

    exports.PackagedProductOptionModel = PackagedProductOptionModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/priceModel.ts":
  /*!************************************************************!*\
    !*** ./src/commonComponents/models/products/priceModel.ts ***!
    \************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsPriceModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var PriceModel = /*#__PURE__*/function () {
      function PriceModel() {
        _classCallCheck(this, PriceModel);

        this.id = '';
        this.startDateTime = new Date(Date.now());
        this.endDateTime = new Date(Date.now());
        this.flatPrice = 0;
        this.formulaPrice = '';
        this.formulaVariables = null;
      } //calculated properties (hence ready-only)
      //is this the default price for the item - should only be one


      _createClass(PriceModel, [{
        key: "isDefaultPrice",
        get: function get() {
          var returnValue = false;
          returnValue = this.startDateTime.getFullYear() === 9999;
          return returnValue;
        } //does the item have a formula price

      }, {
        key: "hasFormula",
        get: function get() {
          return this.formulaPrice !== '';
        } //the start date for the price (formatted to local)

      }, {
        key: "startFormatted",
        get: function get() {
          var returnValue = '';
          returnValue = this.startDateTime.toLocaleDateString();
          return returnValue;
        } //the end date for the price (formatted to local)

      }, {
        key: "endFormatted",
        get: function get() {
          var returnValue = '';
          returnValue = this.endDateTime.toLocaleDateString();
          return returnValue;
        }
      }, {
        key: "formulaVariablesFormatted",
        get: function get() {
          var newLineString = '\r\n';
          var tabString = '\t';
          var returnValue = 'The list of avaiable variables are:' + newLineString;

          if (this.formulaVariables != null) {
            this.formulaVariables.forEach(function (fr) {
              return returnValue += tabString + fr + newLineString;
            });
          }

          return returnValue;
        }
      }]);

      return PriceModel;
    }();

    exports.PriceModel = PriceModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/productAttributeValueModel.ts":
  /*!****************************************************************************!*\
    !*** ./src/commonComponents/models/products/productAttributeValueModel.ts ***!
    \****************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsProductAttributeValueModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var ProductAttributeValueModel = function ProductAttributeValueModel() {
      _classCallCheck(this, ProductAttributeValueModel);

      this.id = '';
      this.valueName = '';
      this.description = '';
      this.isDefault = false;
    };

    exports.ProductAttributeValueModel = ProductAttributeValueModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/productModel.ts":
  /*!**************************************************************!*\
    !*** ./src/commonComponents/models/products/productModel.ts ***!
    \**************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsProductModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); // ReSharper disable once WrongRequireRelativePath
    // ReSharper disable once StringLiteralWrongQuotes

    var ProductModel = function ProductModel() {
      _classCallCheck(this, ProductModel);

      this.id = '';
      this.name = '';
      this.description = '';
    };

    exports.ProductModel = ProductModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/productOptionAttributeValueModel.ts":
  /*!**********************************************************************************!*\
    !*** ./src/commonComponents/models/products/productOptionAttributeValueModel.ts ***!
    \**********************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsProductOptionAttributeValueModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var ProductOptionAttributeValueModel = function ProductOptionAttributeValueModel() {
      _classCallCheck(this, ProductOptionAttributeValueModel);

      this.id = '';
      this.valueName = '';
      this.description = '';
      this.isDefault = false;
    };

    exports.ProductOptionAttributeValueModel = ProductOptionAttributeValueModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/productOptionModel.ts":
  /*!********************************************************************!*\
    !*** ./src/commonComponents/models/products/productOptionModel.ts ***!
    \********************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsProductOptionModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    }); // ReSharper disable once WrongRequireRelativePath
    // ReSharper disable once StringLiteralWrongQuotes

    var ProductOptionModel = function ProductOptionModel() {
      _classCallCheck(this, ProductOptionModel);

      this.id = '';
      this.name = '';
      this.description = '';
    };

    exports.ProductOptionModel = ProductOptionModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/products/productPricingModel.ts":
  /*!*********************************************************************!*\
    !*** ./src/commonComponents/models/products/productPricingModel.ts ***!
    \*********************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsProductsProductPricingModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var ProductPricingModel = function ProductPricingModel() {
      _classCallCheck(this, ProductPricingModel);
    };

    exports.ProductPricingModel = ProductPricingModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/propertyBag/possibleValueModel.ts":
  /*!***********************************************************************!*\
    !*** ./src/commonComponents/models/propertyBag/possibleValueModel.ts ***!
    \***********************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsPropertyBagPossibleValueModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var PossibleValueModel = /*#__PURE__*/function () {
      function PossibleValueModel() {
        _classCallCheck(this, PossibleValueModel);

        this.id = '';
        this.label = '';
        this.value = null;
      }

      _createClass(PossibleValueModel, [{
        key: "clone",
        value: function clone() {
          var returnValue = new PossibleValueModel();
          returnValue.id = this.id;
          returnValue.label = this.label;
          returnValue.value = this.value;
          return returnValue;
        }
      }]);

      return PossibleValueModel;
    }();

    exports.PossibleValueModel = PossibleValueModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/propertyBag/propertyModel.ts":
  /*!******************************************************************!*\
    !*** ./src/commonComponents/models/propertyBag/propertyModel.ts ***!
    \******************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsPropertyBagPropertyModelTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var PropertyModel = /*#__PURE__*/function () {
      function PropertyModel() {
        _classCallCheck(this, PropertyModel);

        this.id = '';
        this.name = '';
        this.selectedValue = null;
        this.possibleValues = null;
        this.enteredValue = null;
      }

      _createClass(PropertyModel, [{
        key: "clone",
        value: function clone() {
          var returnValue = new PropertyModel();
          returnValue.id = this.id;
          returnValue.name = this.name;

          if (this.selectedValue != null) {
            returnValue.selectedValue = this.selectedValue.clone();
          } else {
            returnValue.selectedValue = null;
          }

          if (this.possibleValues != null) {
            returnValue.possibleValues = new Array();
            this.possibleValues.forEach(function (value) {
              returnValue.possibleValues.push(value.clone());
            });
          } else {
            returnValue.possibleValues = null;
          }

          returnValue.enteredValue = this.enteredValue;
          return returnValue;
        }
      }]);

      return PropertyModel;
    }();

    exports.PropertyModel = PropertyModel;
    /***/
  },

  /***/
  "./src/commonComponents/models/requests/products/InitialProductOptionPriceRequest.ts":
  /*!*******************************************************************************************!*\
    !*** ./src/commonComponents/models/requests/products/InitialProductOptionPriceRequest.ts ***!
    \*******************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsRequestsProductsInitialProductOptionPriceRequestTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var InitialProductOptionPriceRequest = function InitialProductOptionPriceRequest() {
      _classCallCheck(this, InitialProductOptionPriceRequest);

      this.option = null;
      this.initialPrice = 0;
    };

    exports.InitialProductOptionPriceRequest = InitialProductOptionPriceRequest;
    /***/
  },

  /***/
  "./src/commonComponents/models/requests/products/ProductOptionPriceRequest.ts":
  /*!************************************************************************************!*\
    !*** ./src/commonComponents/models/requests/products/ProductOptionPriceRequest.ts ***!
    \************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsRequestsProductsProductOptionPriceRequestTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productOptionModel_1 = __webpack_require__(
    /*! ../../products/productOptionModel */
    "./src/commonComponents/models/products/productOptionModel.ts");

    var priceModel_1 = __webpack_require__(
    /*! ../../products/priceModel */
    "./src/commonComponents/models/products/priceModel.ts");

    var moment = __webpack_require__(
    /*! moment */
    "./node_modules/moment/moment.js");

    var ProductOptionPriceRequest = /*#__PURE__*/function () {
      function ProductOptionPriceRequest(prod, pri) {
        _classCallCheck(this, ProductOptionPriceRequest);

        this.option = new productOptionModel_1.ProductOptionModel();
        this.option.id = prod.id;
        this.option.name = prod.name;
        this.option.description = prod.description;
        this.price = new priceModel_1.PriceModel();
        this.price.id = pri.id;
        this.price.startDateTimeString = moment(pri.startDateTime).toISOString();
        this.price.endDateTimeString = moment(pri.endDateTime).toISOString();
        this.price.flatPrice = pri.flatPrice;
        this.price.formulaPrice = pri.formulaPrice;
      }

      _createClass(ProductOptionPriceRequest, [{
        key: "isDateMax",
        value: function isDateMax(dat) {
          return dat.toDateString() === 'Fri Dec 31 9999';
        }
      }]);

      return ProductOptionPriceRequest;
    }();

    exports.ProductOptionPriceRequest = ProductOptionPriceRequest;
    /***/
  },

  /***/
  "./src/commonComponents/models/requests/products/attributeValuesForProductOptionRequest.ts":
  /*!*************************************************************************************************!*\
    !*** ./src/commonComponents/models/requests/products/attributeValuesForProductOptionRequest.ts ***!
    \*************************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsRequestsProductsAttributeValuesForProductOptionRequestTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var attributeModel_1 = __webpack_require__(
    /*! ../../products/attributeModel */
    "./src/commonComponents/models/products/attributeModel.ts");

    var productModel_1 = __webpack_require__(
    /*! ../../products/productModel */
    "./src/commonComponents/models/products/productModel.ts");

    var productOptionModel_1 = __webpack_require__(
    /*! ../../products/productOptionModel */
    "./src/commonComponents/models/products/productOptionModel.ts");

    var AttributeValuesForProductOptionRequest = function AttributeValuesForProductOptionRequest() {
      _classCallCheck(this, AttributeValuesForProductOptionRequest);

      this.product = new productModel_1.ProductModel();
      this.productOption = new productOptionModel_1.ProductOptionModel();
      this.attribute = new attributeModel_1.AttributeModel();
      this.attributeValues = new Array();
    };

    exports.AttributeValuesForProductOptionRequest = AttributeValuesForProductOptionRequest;
    /***/
  },

  /***/
  "./src/commonComponents/models/requests/products/attributeValuesForProductRequest.ts":
  /*!*******************************************************************************************!*\
    !*** ./src/commonComponents/models/requests/products/attributeValuesForProductRequest.ts ***!
    \*******************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsRequestsProductsAttributeValuesForProductRequestTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var attributeModel_1 = __webpack_require__(
    /*! ../../products/attributeModel */
    "./src/commonComponents/models/products/attributeModel.ts");

    var productModel_1 = __webpack_require__(
    /*! ../../products/productModel */
    "./src/commonComponents/models/products/productModel.ts");

    var AttributeValuesForProductRequest = function AttributeValuesForProductRequest() {
      _classCallCheck(this, AttributeValuesForProductRequest);

      this.product = new productModel_1.ProductModel();
      this.attribute = new attributeModel_1.AttributeModel();
      this.attributeValues = new Array();
    };

    exports.AttributeValuesForProductRequest = AttributeValuesForProductRequest;
    /***/
  },

  /***/
  "./src/commonComponents/models/requests/products/attributesForProductOptionRequest.ts":
  /*!********************************************************************************************!*\
    !*** ./src/commonComponents/models/requests/products/attributesForProductOptionRequest.ts ***!
    \********************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsRequestsProductsAttributesForProductOptionRequestTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productModel_1 = __webpack_require__(
    /*! ../../products/productModel */
    "./src/commonComponents/models/products/productModel.ts");

    var productOptionModel_1 = __webpack_require__(
    /*! ../../products/productOptionModel */
    "./src/commonComponents/models/products/productOptionModel.ts");

    var AttributesForProductOptionRequest = function AttributesForProductOptionRequest() {
      _classCallCheck(this, AttributesForProductOptionRequest);

      this.product = new productModel_1.ProductModel();
      this.productOption = new productOptionModel_1.ProductOptionModel();
      this.attributes = new Array();
    };

    exports.AttributesForProductOptionRequest = AttributesForProductOptionRequest;
    /***/
  },

  /***/
  "./src/commonComponents/models/requests/products/attributesForProductRequest.ts":
  /*!**************************************************************************************!*\
    !*** ./src/commonComponents/models/requests/products/attributesForProductRequest.ts ***!
    \**************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsRequestsProductsAttributesForProductRequestTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productModel_1 = __webpack_require__(
    /*! ../../products/productModel */
    "./src/commonComponents/models/products/productModel.ts");

    var AttributesForProductRequest = function AttributesForProductRequest() {
      _classCallCheck(this, AttributesForProductRequest);

      this.product = new productModel_1.ProductModel();
      this.attributes = new Array();
    };

    exports.AttributesForProductRequest = AttributesForProductRequest;
    /***/
  },

  /***/
  "./src/commonComponents/models/requests/products/initialProductPriceRequest.ts":
  /*!*************************************************************************************!*\
    !*** ./src/commonComponents/models/requests/products/initialProductPriceRequest.ts ***!
    \*************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsRequestsProductsInitialProductPriceRequestTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var InitialProductPriceRequest = function InitialProductPriceRequest() {
      _classCallCheck(this, InitialProductPriceRequest);

      this.product = null;
      this.initialPrice = 0;
    };

    exports.InitialProductPriceRequest = InitialProductPriceRequest;
    /***/
  },

  /***/
  "./src/commonComponents/models/requests/products/productOptionsForProductRequest.ts":
  /*!******************************************************************************************!*\
    !*** ./src/commonComponents/models/requests/products/productOptionsForProductRequest.ts ***!
    \******************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsRequestsProductsProductOptionsForProductRequestTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productModel_1 = __webpack_require__(
    /*! ../../products/productModel */
    "./src/commonComponents/models/products/productModel.ts");

    var ProductOptionsForProductRequest = function ProductOptionsForProductRequest() {
      _classCallCheck(this, ProductOptionsForProductRequest);

      this.product = new productModel_1.ProductModel();
      this.options = new Array();
    };

    exports.ProductOptionsForProductRequest = ProductOptionsForProductRequest;
    /***/
  },

  /***/
  "./src/commonComponents/models/requests/products/productPriceRequest.ts":
  /*!******************************************************************************!*\
    !*** ./src/commonComponents/models/requests/products/productPriceRequest.ts ***!
    \******************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsModelsRequestsProductsProductPriceRequestTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productModel_1 = __webpack_require__(
    /*! ../../products/productModel */
    "./src/commonComponents/models/products/productModel.ts");

    var priceModel_1 = __webpack_require__(
    /*! ../../products/priceModel */
    "./src/commonComponents/models/products/priceModel.ts");

    var moment = __webpack_require__(
    /*! moment */
    "./node_modules/moment/moment.js");

    var ProductPriceRequest = /*#__PURE__*/function () {
      function ProductPriceRequest(prod, pri) {
        _classCallCheck(this, ProductPriceRequest);

        this.product = new productModel_1.ProductModel();
        this.product.id = prod.id;
        this.product.name = prod.name;
        this.product.description = prod.description;
        this.price = new priceModel_1.PriceModel();
        this.price.id = pri.id;
        this.price.startDateTimeString = moment(pri.startDateTime).toISOString();
        this.price.endDateTimeString = moment(pri.endDateTime).toISOString();
        this.price.flatPrice = pri.flatPrice;
        this.price.formulaPrice = pri.formulaPrice;
      }

      _createClass(ProductPriceRequest, [{
        key: "isDateMax",
        value: function isDateMax(dat) {
          return dat.toDateString() === 'Fri Dec 31 9999';
        }
      }]);

      return ProductPriceRequest;
    }();

    exports.ProductPriceRequest = ProductPriceRequest;
    /***/
  },

  /***/
  "./src/commonComponents/parsers/genericParser.ts":
  /*!*******************************************************!*\
    !*** ./src/commonComponents/parsers/genericParser.ts ***!
    \*******************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersGenericParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var GenericParser = /*#__PURE__*/function () {
      function GenericParser(parserType) {
        _classCallCheck(this, GenericParser);

        this.parserType = parserType;
      }

      _createClass(GenericParser, [{
        key: "parseResponseInToArray",
        value: function parseResponseInToArray(res) {
          var returnValue = new Array();

          if (res != null) {
            var length = res.length;

            for (var sub = 0; sub < length; sub++) {
              var obj = res[sub];
              var tempValPropertyModel = this.parseObjectIntoAttribute(obj);
              returnValue.push(tempValPropertyModel);
            }
          }

          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Attribute

      }, {
        key: "parseObjectIntoAttribute",
        value: function parseObjectIntoAttribute(obj) {
          var returnValue = null;

          if (obj != null) {
            returnValue = this.create();

            for (var prop in obj) {
              if (obj.hasOwnProperty(prop)) {
                switch (prop) {
                  default:
                    returnValue[prop] = obj[prop];
                }
              }
            }
          }

          return returnValue;
        }
      }, {
        key: "create",
        value: function create() {
          // ReSharper disable once InconsistentNaming
          return new this.parserType(); //create a new instance of T using the constructor function of T
        }
      }]);

      return GenericParser;
    }();

    exports.GenericParser = GenericParser;
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/attributeModelParser.ts":
  /*!****************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/attributeModelParser.ts ***!
    \****************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsAttributeModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var attributeModel_1 = __webpack_require__(
    /*! ../../models/products/attributeModel */
    "./src/commonComponents/models/products/attributeModel.ts");

    var genericParser_1 = __webpack_require__(
    /*! ../genericParser */
    "./src/commonComponents/parsers/genericParser.ts"); //This class is a holdover from when http was in angular/http - it is currently in angular/common/http
    //The class has been left as a place holder to handle future changes


    var AttributeModelParser = /*#__PURE__*/function () {
      function AttributeModelParser() {
        _classCallCheck(this, AttributeModelParser);
      }

      _createClass(AttributeModelParser, null, [{
        key: "parseResponseInToArray",
        //parse the response from the service into an array of Attributes
        value: function parseResponseInToArray(res) {
          var returnValue = this.baseParser.parseResponseInToArray(res);
          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Attribute

      }, {
        key: "parseObjectIntoAttribute",
        value: function parseObjectIntoAttribute(obj) {
          var returnValue = this.baseParser.parseObjectIntoAttribute(obj);
          return returnValue;
        }
      }]);

      return AttributeModelParser;
    }();

    exports.AttributeModelParser = AttributeModelParser;
    AttributeModelParser.baseParser = new genericParser_1.GenericParser(attributeModel_1.AttributeModel);
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/optionPricingModelParser.ts":
  /*!********************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/optionPricingModelParser.ts ***!
    \********************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsOptionPricingModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var optionPricingModel_1 = __webpack_require__(
    /*! ../../models/products/optionPricingModel */
    "./src/commonComponents/models/products/optionPricingModel.ts");

    var productOptionModelParser_1 = __webpack_require__(
    /*! ./productOptionModelParser */
    "./src/commonComponents/parsers/productModels/productOptionModelParser.ts");

    var priceModelParser_1 = __webpack_require__(
    /*! ./priceModelParser */
    "./src/commonComponents/parsers/productModels/priceModelParser.ts");

    var OptionPricingModelParser = /*#__PURE__*/function () {
      function OptionPricingModelParser() {
        _classCallCheck(this, OptionPricingModelParser);
      }

      _createClass(OptionPricingModelParser, null, [{
        key: "parseResponseInToArray",
        value: function parseResponseInToArray(res) {
          var returnValue = new Array();

          if (res != null) {
            var length = res.length;

            for (var sub = 0; sub < length; sub++) {
              var obj = res[sub];
              var tempValProductPricingModel = OptionPricingModelParser.parseObjectIntoProductOptionPricing(obj);
              returnValue.push(tempValProductPricingModel);
            }
          }

          return returnValue;
        }
      }, {
        key: "parseObjectIntoProductOptionPricing",
        value: function parseObjectIntoProductOptionPricing(obj) {
          var returnValue = new optionPricingModel_1.OptionPricingModel();

          for (var prop in obj) {
            if (obj.hasOwnProperty(prop) && obj[prop] != null) {
              var objArray = void 0;
              var length = void 0;
              var sub;

              switch (prop) {
                case 'option':
                  returnValue.option = productOptionModelParser_1.ProductOptionModelParser.parseObjectIntoProductOption(obj[prop]);
                  break;

                case 'prices':
                  returnValue.prices = new Array();
                  objArray = obj[prop];
                  length = objArray.length;

                  for (sub = 0; sub < length; sub++) {
                    var _obj = objArray[sub];
                    var tempValPriceModel = priceModelParser_1.PriceModelParser.parseObjectIntoPrice(_obj);
                    returnValue.prices.push(tempValPriceModel);
                  }

                  break;
                // product options currently do not support formulas
                //case 'formulaVariables':
                //    returnValue.formulaVariables = new Array<string>();
                //    objArray = obj[prop];
                //    length = objArray.length;
                //    for (sub = 0; sub < length; sub++) {
                //        let tempFormulaVarible: string = objArray[sub];
                //        returnValue.formulaVariables.push(tempFormulaVarible);
                //    }
                //break;

                default:
                  returnValue[prop] = obj[prop];
              }
            }
          }

          return returnValue;
        }
      }]);

      return OptionPricingModelParser;
    }();

    exports.OptionPricingModelParser = OptionPricingModelParser;
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/packagedProductDetailModelParser.ts":
  /*!****************************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/packagedProductDetailModelParser.ts ***!
    \****************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsPackagedProductDetailModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var packagedProductDetailModel_1 = __webpack_require__(
    /*! ../../models/products/packagedProductDetailModel */
    "./src/commonComponents/models/products/packagedProductDetailModel.ts");

    var attributeModelParser_1 = __webpack_require__(
    /*! ./attributeModelParser */
    "./src/commonComponents/parsers/productModels/attributeModelParser.ts");

    var PackagedProductDetailModelParser = /*#__PURE__*/function () {
      function PackagedProductDetailModelParser() {
        _classCallCheck(this, PackagedProductDetailModelParser);
      }

      _createClass(PackagedProductDetailModelParser, null, [{
        key: "parseResponseInToArray",
        value: function parseResponseInToArray(res) {
          var returnValue = new Array();

          if (res != null) {
            var length = res.length;

            for (var sub = 0; sub < length; sub++) {
              var obj = res[sub];
              var tempValPropertyModel = this.parseObjectIntoProduct(obj);
              returnValue.push(tempValPropertyModel);
            }
          }

          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Product

      }, {
        key: "parseObjectIntoProduct",
        value: function parseObjectIntoProduct(obj) {
          var returnValue = null;

          if (obj != null) {
            returnValue = new packagedProductDetailModel_1.PackagedProductDetailModel();

            for (var prop in obj) {
              if (obj.hasOwnProperty(prop)) {
                switch (prop) {
                  case 'attribute':
                    returnValue.attribute = attributeModelParser_1.AttributeModelParser.parseObjectIntoAttribute(obj[prop]);
                    break;
                  //case 'possibleValues':
                  //    returnValue.possibleValues = AttributeValueModelParser.parseResponseInToArray(obj[prop]);
                  //    break;

                  default:
                    returnValue[prop] = obj[prop];
                }
              }
            }
          }

          return returnValue;
        }
      }]);

      return PackagedProductDetailModelParser;
    }();

    exports.PackagedProductDetailModelParser = PackagedProductDetailModelParser;
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/packagedProductModelParser.ts":
  /*!**********************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/packagedProductModelParser.ts ***!
    \**********************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsPackagedProductModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var packagedProductModel_1 = __webpack_require__(
    /*! ../../models/products/packagedProductModel */
    "./src/commonComponents/models/products/packagedProductModel.ts");

    var packagedProductDetailModelParser_1 = __webpack_require__(
    /*! ./packagedProductDetailModelParser */
    "./src/commonComponents/parsers/productModels/packagedProductDetailModelParser.ts");

    var packagedProductOptionModelParser_1 = __webpack_require__(
    /*! ./packagedProductOptionModelParser */
    "./src/commonComponents/parsers/productModels/packagedProductOptionModelParser.ts");

    var PackagedProductModelParser = /*#__PURE__*/function () {
      function PackagedProductModelParser() {
        _classCallCheck(this, PackagedProductModelParser);
      }

      _createClass(PackagedProductModelParser, null, [{
        key: "parseResponseInToArray",
        //parse the response from the service into an array of Products
        value: function parseResponseInToArray(res) {
          var returnValue = new Array();

          if (res != null) {
            var length = res.length;

            for (var sub = 0; sub < length; sub++) {
              var obj = res[sub];
              var tempValPropertyModel = this.parseObjectIntoProduct(obj);
              returnValue.push(tempValPropertyModel);
            }
          }

          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Product

      }, {
        key: "parseObjectIntoProduct",
        value: function parseObjectIntoProduct(obj) {
          var returnValue = null;

          if (obj != null) {
            returnValue = new packagedProductModel_1.PackagedProductModel();

            for (var prop in obj) {
              if (obj.hasOwnProperty(prop)) {
                switch (prop) {
                  case 'details':
                    returnValue.details = packagedProductDetailModelParser_1.PackagedProductDetailModelParser.parseResponseInToArray(obj[prop]);
                    break;

                  case 'options':
                    returnValue.options = packagedProductOptionModelParser_1.PackagedProductOptionModelParser.parseResponseInToArray(obj[prop]);
                    break;

                  default:
                    returnValue[prop] = obj[prop];
                }
              }
            }
          }

          return returnValue;
        }
      }]);

      return PackagedProductModelParser;
    }();

    exports.PackagedProductModelParser = PackagedProductModelParser;
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/packagedProductOptionDetailModelParser.ts":
  /*!**********************************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/packagedProductOptionDetailModelParser.ts ***!
    \**********************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsPackagedProductOptionDetailModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var packagedProductOptionDetailModel_1 = __webpack_require__(
    /*! ../../models/products/packagedProductOptionDetailModel */
    "./src/commonComponents/models/products/packagedProductOptionDetailModel.ts");

    var attributeModelParser_1 = __webpack_require__(
    /*! ./attributeModelParser */
    "./src/commonComponents/parsers/productModels/attributeModelParser.ts");

    var PackagedProductOptionDetailModelParser = /*#__PURE__*/function () {
      function PackagedProductOptionDetailModelParser() {
        _classCallCheck(this, PackagedProductOptionDetailModelParser);
      }

      _createClass(PackagedProductOptionDetailModelParser, null, [{
        key: "parseResponseInToArray",
        //parse the response from the service into an array of PackagedProductOptionDetailModel
        value: function parseResponseInToArray(res) {
          var returnValue = new Array();

          if (res != null) {
            var length = res.length;

            for (var sub = 0; sub < length; sub++) {
              var obj = res[sub];
              var tempValPropertyModel = this.parseObjectIntoProduct(obj);
              returnValue.push(tempValPropertyModel);
            }
          }

          return returnValue;
        } //will parse an object into an PackagedProductOptionDetailModel

      }, {
        key: "parseObjectIntoProduct",
        value: function parseObjectIntoProduct(obj) {
          var returnValue = null;

          if (obj != null) {
            returnValue = new packagedProductOptionDetailModel_1.PackagedProductOptionDetailModel();

            for (var prop in obj) {
              if (obj.hasOwnProperty(prop)) {
                switch (prop) {
                  case 'attribute':
                    returnValue.attribute = attributeModelParser_1.AttributeModelParser.parseObjectIntoAttribute(obj[prop]);
                    break;
                  //case 'possibleValues':
                  //    returnValue.possibleValues = AttributeValueModelParser.parseResponseInToArray(obj[prop]);
                  //    break;

                  default:
                    returnValue[prop] = obj[prop];
                }
              }
            }
          }

          return returnValue;
        }
      }]);

      return PackagedProductOptionDetailModelParser;
    }();

    exports.PackagedProductOptionDetailModelParser = PackagedProductOptionDetailModelParser;
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/packagedProductOptionModelParser.ts":
  /*!****************************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/packagedProductOptionModelParser.ts ***!
    \****************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsPackagedProductOptionModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var packagedProductOptionModel_1 = __webpack_require__(
    /*! ../../models/products/packagedProductOptionModel */
    "./src/commonComponents/models/products/packagedProductOptionModel.ts");

    var packagedProductOptionDetailModelParser_1 = __webpack_require__(
    /*! ./packagedProductOptionDetailModelParser */
    "./src/commonComponents/parsers/productModels/packagedProductOptionDetailModelParser.ts");

    var PackagedProductOptionModelParser = /*#__PURE__*/function () {
      function PackagedProductOptionModelParser() {
        _classCallCheck(this, PackagedProductOptionModelParser);
      }

      _createClass(PackagedProductOptionModelParser, null, [{
        key: "parseResponseInToArray",
        //parse the response from the service into an array of Products
        value: function parseResponseInToArray(res) {
          var returnValue = new Array();

          if (res != null) {
            var length = res.length;

            for (var sub = 0; sub < length; sub++) {
              var obj = res[sub];
              var tempValPropertyModel = this.parseObjectIntoProduct(obj);
              returnValue.push(tempValPropertyModel);
            }
          }

          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Product

      }, {
        key: "parseObjectIntoProduct",
        value: function parseObjectIntoProduct(obj) {
          var returnValue = null;

          if (obj != null) {
            returnValue = new packagedProductOptionModel_1.PackagedProductOptionModel();

            for (var prop in obj) {
              if (obj.hasOwnProperty(prop)) {
                switch (prop) {
                  case 'details':
                    returnValue.details = packagedProductOptionDetailModelParser_1.PackagedProductOptionDetailModelParser.parseResponseInToArray(obj[prop]);
                    break;

                  default:
                    returnValue[prop] = obj[prop];
                }
              }
            }
          }

          return returnValue;
        }
      }]);

      return PackagedProductOptionModelParser;
    }();

    exports.PackagedProductOptionModelParser = PackagedProductOptionModelParser;
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/priceModelParser.ts":
  /*!************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/priceModelParser.ts ***!
    \************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsPriceModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var priceModel_1 = __webpack_require__(
    /*! ../../models/products/priceModel */
    "./src/commonComponents/models/products/priceModel.ts");

    var moment = __webpack_require__(
    /*! moment */
    "./node_modules/moment/moment.js"); //This class is a holdover from when http was in angular/http - it is currently in angular/common/http
    //The class has been left as a place holder to handle future changes


    var PriceModelParser = /*#__PURE__*/function () {
      function PriceModelParser() {
        _classCallCheck(this, PriceModelParser);
      }

      _createClass(PriceModelParser, null, [{
        key: "parseResponseInToArray",
        value: function parseResponseInToArray(res) {
          var returnValue = new Array();

          if (res != null) {
            var length = res.length;

            for (var sub = 0; sub < length; sub++) {
              var obj = res[sub];
              var tempValPropertyModel = PriceModelParser.parseObjectIntoPrice(obj);
              returnValue.push(tempValPropertyModel);
            }
          }

          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Product

      }, {
        key: "parseObjectIntoPrice",
        value: function parseObjectIntoPrice(obj) {
          var returnValue = null;

          if (obj != null) {
            returnValue = new priceModel_1.PriceModel();

            for (var prop in obj) {
              if (obj.hasOwnProperty(prop)) {
                switch (prop) {
                  case "endDateTimeString":
                    returnValue.endDateTime = moment(obj[prop]).toDate(); //moment will convert from utc to local time

                    returnValue[prop] = obj[prop];
                    break;

                  case "startDateTimeString":
                    returnValue.startDateTime = moment(obj[prop]).toDate(); //moment will convert from utc to local time

                    returnValue[prop] = obj[prop];
                    break;

                  default:
                    returnValue[prop] = obj[prop];
                }
              }
            }
          }

          return returnValue;
        }
      }]);

      return PriceModelParser;
    }();

    exports.PriceModelParser = PriceModelParser;
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/productAttributeValueModelParser.ts":
  /*!****************************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/productAttributeValueModelParser.ts ***!
    \****************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsProductAttributeValueModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productAttributeValueModel_1 = __webpack_require__(
    /*! ../../models/products/productAttributeValueModel */
    "./src/commonComponents/models/products/productAttributeValueModel.ts");

    var genericParser_1 = __webpack_require__(
    /*! ../genericParser */
    "./src/commonComponents/parsers/genericParser.ts"); //This class is a holdover from when http was in angular/http - it is currently in angular/common/http
    //The class has been left as a place holder to handle future changes


    var ProductAttributeValueModelParser = /*#__PURE__*/function () {
      function ProductAttributeValueModelParser() {
        _classCallCheck(this, ProductAttributeValueModelParser);
      }

      _createClass(ProductAttributeValueModelParser, null, [{
        key: "parseResponseInToArray",
        //parse the response from the service into an array of Attributes
        value: function parseResponseInToArray(res) {
          var returnValue = this.baseParser.parseResponseInToArray(res);
          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Attribute

      }, {
        key: "parseObjectIntoAttribute",
        value: function parseObjectIntoAttribute(obj) {
          var returnValue = this.baseParser.parseObjectIntoAttribute(obj);
          ;
          return returnValue;
        }
      }]);

      return ProductAttributeValueModelParser;
    }();

    exports.ProductAttributeValueModelParser = ProductAttributeValueModelParser;
    ProductAttributeValueModelParser.baseParser = new genericParser_1.GenericParser(productAttributeValueModel_1.ProductAttributeValueModel);
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/productModelParser.ts":
  /*!**************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/productModelParser.ts ***!
    \**************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsProductModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productModel_1 = __webpack_require__(
    /*! ../../models/products/productModel */
    "./src/commonComponents/models/products/productModel.ts");

    var genericParser_1 = __webpack_require__(
    /*! ../genericParser */
    "./src/commonComponents/parsers/genericParser.ts"); //This class is a holdover from when http was in angular/http - it is currently in angular/common/http
    //The class has been left as a place holder to handle future changes


    var ProductModelParser = /*#__PURE__*/function () {
      function ProductModelParser() {
        _classCallCheck(this, ProductModelParser);
      }

      _createClass(ProductModelParser, null, [{
        key: "parseResponseInToArray",
        //parse the response from the service into an array of Products
        value: function parseResponseInToArray(res) {
          var returnValue = this.baseParser.parseResponseInToArray(res);
          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Product

      }, {
        key: "parseObjectIntoProduct",
        value: function parseObjectIntoProduct(obj) {
          var returnValue = this.baseParser.parseObjectIntoAttribute(obj);
          ;
          return returnValue;
        }
      }]);

      return ProductModelParser;
    }();

    exports.ProductModelParser = ProductModelParser;
    ProductModelParser.baseParser = new genericParser_1.GenericParser(productModel_1.ProductModel);
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/productOptionAttributeValueModelParser.ts":
  /*!**********************************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/productOptionAttributeValueModelParser.ts ***!
    \**********************************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsProductOptionAttributeValueModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productOptionAttributeValueModel_1 = __webpack_require__(
    /*! ../../models/products/productOptionAttributeValueModel */
    "./src/commonComponents/models/products/productOptionAttributeValueModel.ts");

    var genericParser_1 = __webpack_require__(
    /*! ../genericParser */
    "./src/commonComponents/parsers/genericParser.ts"); //This class is a holdover from when http was in angular/http - it is currently in angular/common/http
    //The class has been left as a place holder to handle future changes


    var ProductOptionAttributeValueModelParser = /*#__PURE__*/function () {
      function ProductOptionAttributeValueModelParser() {
        _classCallCheck(this, ProductOptionAttributeValueModelParser);
      }

      _createClass(ProductOptionAttributeValueModelParser, null, [{
        key: "parseResponseInToArray",
        //parse the response from the service into an array of Attributes
        value: function parseResponseInToArray(res) {
          var returnValue = this.baseParser.parseResponseInToArray(res);
          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Attribute

      }, {
        key: "parseObjectIntoAttribute",
        value: function parseObjectIntoAttribute(obj) {
          var returnValue = this.baseParser.parseObjectIntoAttribute(obj);
          ;
          return returnValue;
        }
      }]);

      return ProductOptionAttributeValueModelParser;
    }();

    exports.ProductOptionAttributeValueModelParser = ProductOptionAttributeValueModelParser;
    ProductOptionAttributeValueModelParser.baseParser = new genericParser_1.GenericParser(productOptionAttributeValueModel_1.ProductOptionAttributeValueModel);
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/productOptionModelParser.ts":
  /*!********************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/productOptionModelParser.ts ***!
    \********************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsProductOptionModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productOptionModel_1 = __webpack_require__(
    /*! ../../models/products/productOptionModel */
    "./src/commonComponents/models/products/productOptionModel.ts");

    var genericParser_1 = __webpack_require__(
    /*! ../genericParser */
    "./src/commonComponents/parsers/genericParser.ts"); //This class is a holdover from when http was in angular/http - it is currently in angular/common/http
    //The class has been left as a place holder to handle future changes


    var ProductOptionModelParser = /*#__PURE__*/function () {
      function ProductOptionModelParser() {
        _classCallCheck(this, ProductOptionModelParser);
      }

      _createClass(ProductOptionModelParser, null, [{
        key: "parseResponseInToArray",
        //parse the response from the service into an array of Products
        value: function parseResponseInToArray(res) {
          var returnValue = this.baseParser.parseResponseInToArray(res);
          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an Product

      }, {
        key: "parseObjectIntoProductOption",
        value: function parseObjectIntoProductOption(obj) {
          var returnValue = this.baseParser.parseObjectIntoAttribute(obj);
          return returnValue;
        }
      }]);

      return ProductOptionModelParser;
    }();

    exports.ProductOptionModelParser = ProductOptionModelParser;
    ProductOptionModelParser.baseParser = new genericParser_1.GenericParser(productOptionModel_1.ProductOptionModel);
    /***/
  },

  /***/
  "./src/commonComponents/parsers/productModels/productPricingModelParser.ts":
  /*!*********************************************************************************!*\
    !*** ./src/commonComponents/parsers/productModels/productPricingModelParser.ts ***!
    \*********************************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsParsersProductModelsProductPricingModelParserTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var productPricingModel_1 = __webpack_require__(
    /*! ../../models/products/productPricingModel */
    "./src/commonComponents/models/products/productPricingModel.ts");

    var productModelParser_1 = __webpack_require__(
    /*! ./productModelParser */
    "./src/commonComponents/parsers/productModels/productModelParser.ts");

    var priceModelParser_1 = __webpack_require__(
    /*! ./priceModelParser */
    "./src/commonComponents/parsers/productModels/priceModelParser.ts"); //This class is a holdover from when http was in angular/http - it is currently in angular/common/http
    //The class has been left as a place holder to handle future changes


    var ProductPricingModelParser = /*#__PURE__*/function () {
      function ProductPricingModelParser() {
        _classCallCheck(this, ProductPricingModelParser);
      }

      _createClass(ProductPricingModelParser, null, [{
        key: "parseResponseInToArray",
        value: function parseResponseInToArray(res) {
          var returnValue = new Array();

          if (res != null) {
            var length = res.length;

            for (var sub = 0; sub < length; sub++) {
              var obj = res[sub];
              var tempValProductPricingModel = this.parseObjectIntoProductPricing(obj);
              returnValue.push(tempValProductPricingModel);
            }
          }

          return returnValue;
        } //common functionality of all parsing methods - will parse an object into an ProductPricing

      }, {
        key: "parseObjectIntoProductPricing",
        value: function parseObjectIntoProductPricing(obj) {
          var returnValue = new productPricingModel_1.ProductPricingModel();

          for (var prop in obj) {
            if (obj.hasOwnProperty(prop) && obj[prop] != null) {
              var objArray = void 0;
              var length = void 0;
              var sub;

              switch (prop) {
                case 'product':
                  returnValue.product = productModelParser_1.ProductModelParser.parseObjectIntoProduct(obj[prop]);
                  break;

                case 'prices':
                  returnValue.prices = new Array();
                  objArray = obj[prop];
                  length = objArray.length;

                  for (sub = 0; sub < length; sub++) {
                    var _obj2 = objArray[sub];
                    var tempValPriceModel = priceModelParser_1.PriceModelParser.parseObjectIntoPrice(_obj2);
                    returnValue.prices.push(tempValPriceModel);
                  }

                  break;

                case 'formulaVariables':
                  returnValue.formulaVariables = new Array();
                  objArray = obj[prop];
                  length = objArray.length;

                  for (sub = 0; sub < length; sub++) {
                    var tempFormulaVarible = objArray[sub];
                    returnValue.formulaVariables.push(tempFormulaVarible);
                  }

                  break;

                default:
                  returnValue[prop] = obj[prop];
              }
            }
          }

          return returnValue;
        }
      }]);

      return ProductPricingModelParser;
    }();

    exports.ProductPricingModelParser = ProductPricingModelParser;
    /***/
  },

  /***/
  "./src/commonComponents/service/attribute.service.ts":
  /*!***********************************************************!*\
    !*** ./src/commonComponents/service/attribute.service.ts ***!
    \***********************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsServiceAttributeServiceTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var operators_1 = __webpack_require__(
    /*! rxjs/operators */
    "./node_modules/rxjs/_esm2015/operators/index.js");

    var HttpErrorHandler_1 = __webpack_require__(
    /*! ../helpers/HttpErrorHandler */
    "./src/commonComponents/helpers/HttpErrorHandler.ts");

    var attributeModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/attributeModelParser */
    "./src/commonComponents/parsers/productModels/attributeModelParser.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var i2 = __webpack_require__(
    /*! ../service/serviceLocator.service */
    "./src/commonComponents/service/serviceLocator.service.ts");

    var AttributeService = /*#__PURE__*/function () {
      function AttributeService(http, configService) {
        _classCallCheck(this, AttributeService);

        this.http = http;
        this.configService = configService;
      }

      _createClass(AttributeService, [{
        key: "setAttribute",
        value: function setAttribute(attribute) {
          var _this47 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this47.saveAttribute(config, attribute);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveAttribute",
        value: function saveAttribute(locations, attribute) {
          return this.http.post(locations.attributeLocation, attribute).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "getAttributes",
        value: function getAttributes() {
          var _this48 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this48.handleConfigurationResultForGetAttributes(config);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetAttributes",
        value: function handleConfigurationResultForGetAttributes(conf) {
          return this.http.get(conf.attributesLocation).pipe(operators_1.map(this.handleGetAttributesResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "handleGetAttributesResult",
        value: function handleGetAttributesResult(res) {
          var returnValue = attributeModelParser_1.AttributeModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }]);

      return AttributeService;
    }();

    exports.AttributeService = AttributeService;

    AttributeService.??fac = function AttributeService_Factory(t) {
      return new (t || AttributeService)(i0.????inject(i1.HttpClient), i0.????inject(i2.ServiceLocatorService));
    };

    AttributeService.??prov = i0.????defineInjectable({
      token: AttributeService,
      factory: AttributeService.??fac
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(AttributeService, [{
        type: core_1.Injectable
      }], function () {
        return [{
          type: i1.HttpClient
        }, {
          type: i2.ServiceLocatorService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/commonComponents/service/product.service.ts":
  /*!*********************************************************!*\
    !*** ./src/commonComponents/service/product.service.ts ***!
    \*********************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsServiceProductServiceTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var http_1 = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var operators_1 = __webpack_require__(
    /*! rxjs/operators */
    "./node_modules/rxjs/_esm2015/operators/index.js");

    var HttpErrorHandler_1 = __webpack_require__(
    /*! ../helpers/HttpErrorHandler */
    "./src/commonComponents/helpers/HttpErrorHandler.ts");

    var productModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/productModelParser */
    "./src/commonComponents/parsers/productModels/productModelParser.ts");

    var attributeModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/attributeModelParser */
    "./src/commonComponents/parsers/productModels/attributeModelParser.ts");

    var productAttributeValueModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/productAttributeValueModelParser */
    "./src/commonComponents/parsers/productModels/productAttributeValueModelParser.ts");

    var attributesForProductRequest_1 = __webpack_require__(
    /*! ../models/requests/products/attributesForProductRequest */
    "./src/commonComponents/models/requests/products/attributesForProductRequest.ts");

    var attributeValuesForProductRequest_1 = __webpack_require__(
    /*! ../models/requests/products/attributeValuesForProductRequest */
    "./src/commonComponents/models/requests/products/attributeValuesForProductRequest.ts");

    var initialProductPriceRequest_1 = __webpack_require__(
    /*! ../models/requests/products/initialProductPriceRequest */
    "./src/commonComponents/models/requests/products/initialProductPriceRequest.ts");

    var productPricingModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/productPricingModelParser */
    "./src/commonComponents/parsers/productModels/productPricingModelParser.ts");

    var productPriceRequest_1 = __webpack_require__(
    /*! ../models/requests/products/productPriceRequest */
    "./src/commonComponents/models/requests/products/productPriceRequest.ts");

    var packagedProductModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/packagedProductModelParser */
    "./src/commonComponents/parsers/productModels/packagedProductModelParser.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var i2 = __webpack_require__(
    /*! ../service/serviceLocator.service */
    "./src/commonComponents/service/serviceLocator.service.ts");

    var ProductService = /*#__PURE__*/function () {
      function ProductService(http, configService) {
        _classCallCheck(this, ProductService);

        this.http = http;
        this.configService = configService;
      }

      _createClass(ProductService, [{
        key: "setProduct",
        value: function setProduct(product) {
          var _this49 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this49.saveProduct(config, product);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveProduct",
        value: function saveProduct(locations, product) {
          return this.http.post(locations.productLocation, product).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "getProducts",
        value: function getProducts() {
          var _this50 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this50.handleConfigurationResultForGetProducts(config);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetProducts",
        value: function handleConfigurationResultForGetProducts(conf) {
          return this.http.get(conf.productsLocation).pipe(operators_1.map(this.handleGetProductsResult), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleGetProductsResult",
        value: function handleGetProductsResult(res) {
          var returnValue = productModelParser_1.ProductModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }, {
        key: "getAttributesForProduct",
        value: function getAttributesForProduct(product) {
          var _this51 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this51.handleConfigurationResultForGetAttributesForProduct(config, product);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetAttributesForProduct",
        value: function handleConfigurationResultForGetAttributesForProduct(conf, product) {
          var headers = new http_1.HttpHeaders().set('Content-Type', 'application/json');
          var uri = conf.productLocation + "/" + product.id + "/Attributes";
          return this.http.get(conf.getProductAttributeLocation, {
            headers: headers
          }).pipe(operators_1.map(this.handleGetProductAttributeResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "handleGetProductAttributeResult",
        value: function handleGetProductAttributeResult(res) {
          var returnValue = attributeModelParser_1.AttributeModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }, {
        key: "setAttributesForProduct",
        value: function setAttributesForProduct(product, attributes) {
          var _this52 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this52.saveAttributesForProduct(config, product, attributes);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveAttributesForProduct",
        value: function saveAttributesForProduct(locations, product, attributes) {
          var request = new attributesForProductRequest_1.AttributesForProductRequest();
          request.product = product;
          request.attributes = attributes;
          var uri = locations.productLocation + "/Attributes";
          return this.http.post(uri, request).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "getAttributeValuesForProduct",
        value: function getAttributeValuesForProduct(product, attribute) {
          var _this53 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this53.handleConfigurationResultForGetAttributeValuessForProduct(config, product, attribute);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetAttributeValuessForProduct",
        value: function handleConfigurationResultForGetAttributeValuessForProduct(conf, product, attribute) {
          var headers = new http_1.HttpHeaders().set('Content-Type', 'application/json');
          var uri = conf.productLocation + "/" + product.id + "/Attribute/" + attribute.id;
          return this.http.get(uri, {
            headers: headers
          }).pipe(operators_1.map(this.handleGetProductAttributeValueResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "handleGetProductAttributeValueResult",
        value: function handleGetProductAttributeValueResult(res) {
          var returnValue = productAttributeValueModelParser_1.ProductAttributeValueModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }, {
        key: "setAttributeValuesForProduct",
        value: function setAttributeValuesForProduct(product, attribute, values) {
          var _this54 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this54.saveAttributeValuesForProduct(config, product, attribute, values);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveAttributeValuesForProduct",
        value: function saveAttributeValuesForProduct(locations, product, attribute, values) {
          var request = new attributeValuesForProductRequest_1.AttributeValuesForProductRequest();
          request.product = product;
          request.attribute = attribute;
          request.attributeValues = values;
          var uri = locations.productLocation + "/AttributeValues";
          return this.http.post(uri, request).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "createInitialProductPricing",
        value: function createInitialProductPricing(product, initialPrice) {
          var _this55 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this55.saveInitialProductPricing(config, product, initialPrice);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveInitialProductPricing",
        value: function saveInitialProductPricing(locations, product, initialPrice) {
          var request = new initialProductPriceRequest_1.InitialProductPriceRequest();
          request.product = product;
          request.initialPrice = initialPrice;
          var uri = locations.productPricingLocation + "/NewProduct";
          return this.http.post(uri, request).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "getProductsWithNoPrices",
        value: function getProductsWithNoPrices() {
          var _this56 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this56.handleConfigurationResultForGetProductsWithNoPrices(config);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetProductsWithNoPrices",
        value: function handleConfigurationResultForGetProductsWithNoPrices(conf) {
          var uri = conf.productPricingLocation + "/Products";
          return this.http.get(uri).pipe(operators_1.map(this.handleGetProductsResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "getProductsWithPrices",
        value: function getProductsWithPrices() {
          var _this57 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this57.handleConfigurationResultForGetProductsWithPrices(config);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetProductsWithPrices",
        value: function handleConfigurationResultForGetProductsWithPrices(conf) {
          return this.http.get(conf.productPricingLocation).pipe(operators_1.map(this.handlePricingForProductsResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "handlePricingForProductsResult",
        value: function handlePricingForProductsResult(res) {
          var returnValue = productPricingModelParser_1.ProductPricingModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }, {
        key: "setProductPrice",
        value: function setProductPrice(product, price) {
          var _this58 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this58.saveProductPrice(config, product, price);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveProductPrice",
        value: function saveProductPrice(conf, product, price) {
          var request = new productPriceRequest_1.ProductPriceRequest(product, price);
          return this.http.post(conf.productPricingLocation, request).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "getPackagedProducts",
        value: function getPackagedProducts() {
          var _this59 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this59.handleConfigurationResultForGetPackagedProducts(config);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetPackagedProducts",
        value: function handleConfigurationResultForGetPackagedProducts(conf) {
          return this.http.get(conf.packagedProductsLocation).pipe(operators_1.map(this.handleGetPackagedProductsResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "handleGetPackagedProductsResult",
        value: function handleGetPackagedProductsResult(res) {
          var returnValue = packagedProductModelParser_1.PackagedProductModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }]);

      return ProductService;
    }();

    exports.ProductService = ProductService;

    ProductService.??fac = function ProductService_Factory(t) {
      return new (t || ProductService)(i0.????inject(i1.HttpClient), i0.????inject(i2.ServiceLocatorService));
    };

    ProductService.??prov = i0.????defineInjectable({
      token: ProductService,
      factory: ProductService.??fac
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductService, [{
        type: core_1.Injectable
      }], function () {
        return [{
          type: i1.HttpClient
        }, {
          type: i2.ServiceLocatorService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/commonComponents/service/productOption.service.ts":
  /*!***************************************************************!*\
    !*** ./src/commonComponents/service/productOption.service.ts ***!
    \***************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsServiceProductOptionServiceTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var http_1 = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var operators_1 = __webpack_require__(
    /*! rxjs/operators */
    "./node_modules/rxjs/_esm2015/operators/index.js");

    var HttpErrorHandler_1 = __webpack_require__(
    /*! ../helpers/HttpErrorHandler */
    "./src/commonComponents/helpers/HttpErrorHandler.ts");

    var productOptionsForProductRequest_1 = __webpack_require__(
    /*! ../models/requests/products/productOptionsForProductRequest */
    "./src/commonComponents/models/requests/products/productOptionsForProductRequest.ts");

    var productOptionModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/productOptionModelParser */
    "./src/commonComponents/parsers/productModels/productOptionModelParser.ts");

    var attributeModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/attributeModelParser */
    "./src/commonComponents/parsers/productModels/attributeModelParser.ts");

    var attributesForProductOptionRequest_1 = __webpack_require__(
    /*! ../models/requests/products/attributesForProductOptionRequest */
    "./src/commonComponents/models/requests/products/attributesForProductOptionRequest.ts");

    var productOptionAttributeValueModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/productOptionAttributeValueModelParser */
    "./src/commonComponents/parsers/productModels/productOptionAttributeValueModelParser.ts");

    var attributeValuesForProductOptionRequest_1 = __webpack_require__(
    /*! ../models/requests/products/attributeValuesForProductOptionRequest */
    "./src/commonComponents/models/requests/products/attributeValuesForProductOptionRequest.ts");

    var optionPricingModelParser_1 = __webpack_require__(
    /*! ../parsers/productModels/optionPricingModelParser */
    "./src/commonComponents/parsers/productModels/optionPricingModelParser.ts");

    var InitialProductOptionPriceRequest_1 = __webpack_require__(
    /*! ../models/requests/products/InitialProductOptionPriceRequest */
    "./src/commonComponents/models/requests/products/InitialProductOptionPriceRequest.ts");

    var ProductOptionPriceRequest_1 = __webpack_require__(
    /*! ../models/requests/products/ProductOptionPriceRequest */
    "./src/commonComponents/models/requests/products/ProductOptionPriceRequest.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var i2 = __webpack_require__(
    /*! ../service/serviceLocator.service */
    "./src/commonComponents/service/serviceLocator.service.ts");

    var ProductOptionService = /*#__PURE__*/function () {
      function ProductOptionService(http, configService) {
        _classCallCheck(this, ProductOptionService);

        this.http = http;
        this.configService = configService;
      }

      _createClass(ProductOptionService, [{
        key: "setProductOption",
        value: function setProductOption(productOption) {
          var _this60 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this60.saveProductOption(config, productOption);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveProductOption",
        value: function saveProductOption(locations, productOption) {
          return this.http.post(locations.productOptionLocation, productOption).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "setProductionOptionsForProduct",
        value: function setProductionOptionsForProduct(product, productOptions) {
          var _this61 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this61.saveProductionOptionsForProduct(config, product, productOptions);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveProductionOptionsForProduct",
        value: function saveProductionOptionsForProduct(locations, product, productOptions) {
          var request = new productOptionsForProductRequest_1.ProductOptionsForProductRequest();
          request.product = product;
          request.options = productOptions;
          var uri = locations.productLocation = '/ProductOptions';
          return this.http.post(uri, request).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "getProductOptions",
        value: function getProductOptions() {
          var _this62 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this62.handleConfigurationResultForGetProductOptions(config);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetProductOptions",
        value: function handleConfigurationResultForGetProductOptions(conf) {
          return this.http.get(conf.productOptionsLocation).pipe(operators_1.map(this.handleGetProductOptionsResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "getOptionsForProduct",
        value: function getOptionsForProduct(product) {
          var _this63 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this63.handleConfigurationResultForGetOptionsForProduct(config, product);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetOptionsForProduct",
        value: function handleConfigurationResultForGetOptionsForProduct(conf, product) {
          var headers = new http_1.HttpHeaders().set('Content-Type', 'application/json');
          debugger; //let search: HttpParams = new HttpParams();
          //search = search.append("productId", product.id);

          var uri = conf.getProductOptionsLocation + "/" + product.id + "/ProductOptions";
          return this.http.get(uri, {
            headers: headers
          }).pipe(operators_1.map(this.handleGetProductOptionsResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "handleGetProductOptionsResult",
        value: function handleGetProductOptionsResult(res) {
          var returnValue = productOptionModelParser_1.ProductOptionModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }, {
        key: "getAttributesForProductOption",
        value: function getAttributesForProductOption(product, productOption) {
          var _this64 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this64.handleConfigurationResultForGetAttributesForProductOption(config, product, productOption);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetAttributesForProductOption",
        value: function handleConfigurationResultForGetAttributesForProductOption(conf, product, productOption) {
          var headers = new http_1.HttpHeaders().set('Content-Type', 'application/json'); // let search: HttpParams = new HttpParams();
          // search = search.append("productId", product.id);
          // search = search.append("productOptionId",productOption.id);

          var uri = conf.productLocation + "/" + product.id + "/ProductOption/" + productOption.id + "/Attributes";
          return this.http.get(uri, {
            headers: headers
          }).pipe(operators_1.map(this.handleGetProductOptionAttributeResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "handleGetProductOptionAttributeResult",
        value: function handleGetProductOptionAttributeResult(res) {
          var returnValue = attributeModelParser_1.AttributeModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }, {
        key: "setAttributesForProductOption",
        value: function setAttributesForProductOption(product, productOption, attributes) {
          var _this65 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this65.saveAttributesForProductOption(config, product, productOption, attributes);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveAttributesForProductOption",
        value: function saveAttributesForProductOption(locations, product, productOption, attributes) {
          var request = new attributesForProductOptionRequest_1.AttributesForProductOptionRequest();
          request.product = product;
          request.productOption = productOption;
          request.attributes = attributes;
          var uri = locations.productOptionLocation + "/Attributes";
          return this.http.post(uri, request).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "getAttributeValuesForProductOption",
        value: function getAttributeValuesForProductOption(product, productOption, attribute) {
          var _this66 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this66.handleConfigurationResultForGetAttributeValuesForProductOption(config, product, productOption, attribute);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetAttributeValuesForProductOption",
        value: function handleConfigurationResultForGetAttributeValuesForProductOption(conf, product, productOption, attribute) {
          var headers = new http_1.HttpHeaders().set('Content-Type', 'application/json'); // let search: HttpParams = new HttpParams();
          // search = search.append("productId", product.id);
          // search = search.append("productOptionId", productOption.id);
          // search = search.append("attributeId",attribute.id);

          var uri = conf.productLocation + "/" + product.id + "/ProductOption/" + productOption.id + "/Attribute/" + attribute.id;
          return this.http.get(uri, {
            headers: headers
          }).pipe(operators_1.map(this.handleGetProductOptionAttributeValuesResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "handleGetProductOptionAttributeValuesResult",
        value: function handleGetProductOptionAttributeValuesResult(res) {
          var returnValue = productOptionAttributeValueModelParser_1.ProductOptionAttributeValueModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }, {
        key: "setAttributeValuesForProductOption",
        value: function setAttributeValuesForProductOption(product, productOption, attribute, values) {
          var _this67 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this67.saveAttributeValuesForProductOption(config, product, productOption, attribute, values);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveAttributeValuesForProductOption",
        value: function saveAttributeValuesForProductOption(locations, product, productOption, attribute, values) {
          var request = new attributeValuesForProductOptionRequest_1.AttributeValuesForProductOptionRequest();
          request.product = product;
          request.productOption = productOption;
          request.attribute = attribute;
          request.attributeValues = values;
          var uri = locations.productOptionLocation + "/AttributeValues";
          return this.http.post(uri, request).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "getProductOptionsWithPrices",
        value: function getProductOptionsWithPrices() {
          var _this68 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this68.handleConfigurationResultForGetProductOptionsWithPrices(config);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetProductOptionsWithPrices",
        value: function handleConfigurationResultForGetProductOptionsWithPrices(conf) {
          return this.http.get(conf.productOptionPricingLocation).pipe(operators_1.map(this.handlePricingForProductsResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "handlePricingForProductsResult",
        value: function handlePricingForProductsResult(res) {
          var returnValue = optionPricingModelParser_1.OptionPricingModelParser.parseResponseInToArray(res);
          return returnValue;
        }
      }, {
        key: "getProductOptionsWithNoPrices",
        value: function getProductOptionsWithNoPrices() {
          var _this69 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this69.handleConfigurationResultForGetProductOptionssWithNoPrices(config);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "handleConfigurationResultForGetProductOptionssWithNoPrices",
        value: function handleConfigurationResultForGetProductOptionssWithNoPrices(conf) {
          var uri = conf.productOptionPricingLocation + "/ProductOptions";
          return this.http.get(uri).pipe(operators_1.map(this.handleGetProductOptionsResult), operators_1.catchError(HttpErrorHandler_1.HttpErrorHandler.errorHandler));
        }
      }, {
        key: "createInitialProductPricing",
        value: function createInitialProductPricing(productOption, initialPrice) {
          var _this70 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this70.saveInitialProductPricing(config, productOption, initialPrice);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveInitialProductPricing",
        value: function saveInitialProductPricing(locations, productOption, initialPrice) {
          var request = new InitialProductOptionPriceRequest_1.InitialProductOptionPriceRequest();
          request.option = productOption;
          request.initialPrice = initialPrice;
          var uri = locations.productOptionPricingLocation + "/NewProductOption";
          return this.http.post(uri, request).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "setProductOptionPrice",
        value: function setProductOptionPrice(option, price) {
          var _this71 = this;

          return this.configService.getServiceLocation().pipe(operators_1.switchMap(function (config) {
            return _this71.saveProductOptionPrice(config, option, price);
          }), operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }, {
        key: "saveProductOptionPrice",
        value: function saveProductOptionPrice(conf, option, price) {
          var request = new ProductOptionPriceRequest_1.ProductOptionPriceRequest(option, price);
          return this.http.post(conf.productOptionPricingLocation, request).pipe(operators_1.catchError(function (err) {
            return HttpErrorHandler_1.HttpErrorHandler.errorHandler(err);
          }));
        }
      }]);

      return ProductOptionService;
    }();

    exports.ProductOptionService = ProductOptionService;

    ProductOptionService.??fac = function ProductOptionService_Factory(t) {
      return new (t || ProductOptionService)(i0.????inject(i1.HttpClient), i0.????inject(i2.ServiceLocatorService));
    };

    ProductOptionService.??prov = i0.????defineInjectable({
      token: ProductOptionService,
      factory: ProductOptionService.??fac
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ProductOptionService, [{
        type: core_1.Injectable
      }], function () {
        return [{
          type: i1.HttpClient
        }, {
          type: i2.ServiceLocatorService
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/commonComponents/service/serviceLocator.service.ts":
  /*!****************************************************************!*\
    !*** ./src/commonComponents/service/serviceLocator.service.ts ***!
    \****************************************************************/

  /*! no static exports found */

  /***/
  function srcCommonComponentsServiceServiceLocatorServiceTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var rxjs_1 = __webpack_require__(
    /*! rxjs */
    "./node_modules/rxjs/_esm2015/index.js");

    var ServiceLocations_1 = __webpack_require__(
    /*! ../models/ServiceLocations */
    "./src/commonComponents/models/ServiceLocations.ts");

    var i0 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var i1 = __webpack_require__(
    /*! @angular/common/http */
    "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");

    var ServiceLocatorService = /*#__PURE__*/function () {
      function ServiceLocatorService(http) {
        _classCallCheck(this, ServiceLocatorService);

        this.http = http;
      }

      _createClass(ServiceLocatorService, [{
        key: "setUrl",
        value: function setUrl(url) {
          this.localUrl = url;
        }
      }, {
        key: "getServiceLocation",
        value: function getServiceLocation() {
          var hostLocation = this.localUrl;
          var bannerfileUploadPath = '/systemdata/BannerFileUpload';
          var bannerFileListPath = '/systemdata/GetBannerFiles';
          var footerfileUploadPath = '/systemdata/FooterFileUpload';
          var footerFileListPath = '/systemdata/GetFooterFiles';
          var getSystemConfigurationPath = '/systemdata/GetSystemConfiguration';
          var setSystemConfigurationPath = '/systemdata/SetSystemConfiguration';
          var userServicePath = '/systemdata/GetUsers';
          var addUserServicePath = '/systemdata/AddNewUser';
          var rolesServicePath = '/systemdata/GetRoles';
          var setUserRolesPath = '/systemdata/SetUserRoles';
          var getCustomersPath = '/People/GetCustomers';
          var setCustomerPath = '/People/SetCustomer';
          var getStatesPath = '/People/GetStates';
          var getPhoneNumberTypesPath = '/People/GetPhoneNumberTypes';
          var customerPath = '/Customer';
          var customersPath = '/Customers';
          var statesPath = '/States';
          var phoneNumberTypesPath = '/PhoneNumberTypes';
          var productPath = '/Product';
          var productsPath = '/Products';
          var productOptionPath = '/ProductOption';
          var productOptionsPath = '/ProductOptions';
          var attributePath = '/Attribute';
          var attributesPath = '/Attributes';
          var productPricingPath = '/ProductPricing';
          var productOptionPricingPath = '/ProductOptionPricing';
          var packagedProductsPath = '/PackagedProducts'; //const getProductsPath: string = '/Products';
          //const productPath: string = '/Product';

          var getProductOptionsPath = '/ProductOptions';
          var setProductOptionPath = '/ProductOption';
          var getAttributePath = '/Attributes';
          var setAttributePath = '/Attribute';
          var setProductOptionsForProductPath = '/Product/ProductOptions';
          var getGetOptionsForProductPath = '/ProductOptions';
          var getProductAttributePath = '/Product/Attributes';
          var setAttributesForProductPath = '/Product/Attributes';
          var getAttributesForProductOptionPath = '/OriginalProduct/GetAttributesForProductOption';
          var setAttributesForProductOptionPath = '/OriginalProduct/SetAttributesForProductOption';
          var getAttributeValuesForProductPath = '/OriginalProduct/GetAttributeValuesForProduct';
          var setAttributeValuesForProductPath = '/OriginalProduct/SetAttributeValuesForProduct';
          var getProductOptionAttributeValuesPath = '/OriginalProduct/GetAttributeValuesForProductOption';
          var setProductOptionAttributeValuesPath = '/OriginalProduct/SetAttributeValuesForProductOption';
          var createInitialProductPricingPath = '/OriginalProduct/CreateInitialProductPrice';
          var getProductsWithNoPricesPath = '/OriginalProduct/GetProductsWithNoPrices';
          var getPricingForProductsPath = '/OriginalProduct/GetPricingForProducts';
          var setProductPricePath = '/OriginalProduct/SetProductPrice';
          var getProductOptionsWithPricesPath = '/OriginalProduct/GetPricingFromProductOptions';
          var getProductOptionsWithNoPricesPath = '/OriginalProduct/GetProductOptionsWithNoPrices';
          var createInitialOptionPricePath = '/OriginalProduct/CreateInitialOptionPrice';
          var setProductOptionPricePath = '/OriginalProduct/SetProductOptionPrice';
          var getPackagedProductsPath = '/OriginalProduct/GetPackagedProducts';
          var returnValue = new ServiceLocations_1.ServiceLocations();
          returnValue.bannerFileUploadServiceLocation = hostLocation + bannerfileUploadPath;
          returnValue.bannerFileListServiceLocation = hostLocation + bannerFileListPath;
          returnValue.footerFileUploadServiceLocation = hostLocation + footerfileUploadPath;
          returnValue.footerFileListServiceLocation = hostLocation + footerFileListPath;
          returnValue.getSystemConfigurationServiceLocation = hostLocation + getSystemConfigurationPath;
          returnValue.setSystemConfigurationServiceLocation = hostLocation + setSystemConfigurationPath;
          returnValue.usersServiceLocation = hostLocation + userServicePath;
          returnValue.addUserServiceLocation = hostLocation + addUserServicePath;
          returnValue.rolesServiceLocation = hostLocation + rolesServicePath;
          returnValue.setUserRolesLocation = hostLocation + setUserRolesPath; // returnValue.getCustomersLocation = hostLocation + getCustomersPath;
          // returnValue.setCustomerLocation = hostLocation + setCustomerPath;
          // returnValue.getStatesLocation = hostLocation + getStatesPath;
          // returnValue.getPhoneNumberTypesLocation = hostLocation + getPhoneNumberTypesPath;

          returnValue.customerLocation = hostLocation + customerPath;
          returnValue.customersLocation = hostLocation + customersPath;
          returnValue.statesLocation = hostLocation + statesPath;
          returnValue.phoneNumberTypesLocation = hostLocation + phoneNumberTypesPath;
          returnValue.productLocation = hostLocation + productPath;
          returnValue.productsLocation = hostLocation + productsPath;
          returnValue.productOptionLocation = hostLocation + productOptionPath;
          returnValue.productOptionsLocation = hostLocation + productOptionsPath;
          returnValue.attributeLocation = hostLocation + attributePath;
          returnValue.attributesLocation = hostLocation + attributesPath;
          returnValue.productPricingLocation = hostLocation + productPricingPath;
          returnValue.productOptionPricingLocation = hostLocation + productOptionPricingPath;
          returnValue.packagedProductsLocation = hostLocation + packagedProductsPath; // returnValue.getProductsLocation = hostLocation + getProductsPath;
          // returnValue.setProductLocation = hostLocation + productPath;
          // returnValue.getProductOptionsLocation = hostLocation + productPath;
          // returnValue.setProductOptionLocation = hostLocation + setProductOptionPath;
          // returnValue.getOptionsForProductLocation = hostLocation + getGetOptionsForProductPath;
          // returnValue.setProductOptionsForProductLocation = hostLocation + setProductOptionsForProductPath;
          // returnValue.getAttributesLocation = hostLocation + getAttributePath;
          // returnValue.setAttributeLocation = hostLocation + setAttributePath;
          // returnValue.getProductAttributeLocation = hostLocation + getProductAttributePath;
          // returnValue.setAttributesForProductLocation = hostLocation + setAttributesForProductPath;
          // returnValue.getAttributesForProductOptionLocation = hostLocation + getAttributesForProductOptionPath;
          // returnValue.setAttributesForProductOptionLocation = hostLocation + setAttributesForProductOptionPath;
          // returnValue.getProductAttributeValuesLocation = hostLocation + getAttributeValuesForProductPath;
          // returnValue.setProductAttributeValuesLocation = hostLocation + setAttributeValuesForProductPath;
          // returnValue.getProductOptionAttributeValuesLocation = hostLocation + getProductOptionAttributeValuesPath;
          // returnValue.setProductOptionAttributeValuesLocation = hostLocation + setProductOptionAttributeValuesPath;
          // returnValue.createInitialProductPricingLocation = hostLocation + createInitialProductPricingPath;
          // returnValue.getProductsWithNoPricesLocation = hostLocation + getProductsWithNoPricesPath;
          // returnValue.getPricingForProductsLocation = hostLocation + getPricingForProductsPath;
          // returnValue.setProductPriceLocation = hostLocation + setProductPricePath;
          // returnValue.getProductOptionsWithPricesLocation = hostLocation + getProductOptionsWithPricesPath;
          // returnValue.getProductOptionsWithNoPricesLocation = hostLocation + getProductOptionsWithNoPricesPath;
          // returnValue.createInitialOptionPriceLocation = hostLocation + createInitialOptionPricePath;
          // returnValue.setProductOptionPriceLocation = hostLocation + setProductOptionPricePath;
          // returnValue.getPackagedProductsLocation = hostLocation + getPackagedProductsPath;

          return rxjs_1.of(returnValue); //*******************************************************************************************************************************************
          //The below functionality was orginal with the application and will need to be changed to use the newest patterns with rxjs and httpclient
          //*******************************************************************************************************************************************
          //This is a service call to get the locations of all the service from the web server
          //var url: string = localUrl + "/api/systemdata/GetServiceLocation";
          //return this.http.get(url)
          //    .map(this.extractData)
          //    .catch(this.errorHandler);//should use the global error handler commoncomponents/helpers/HttpErrorHandler
        }
      }]);

      return ServiceLocatorService;
    }();

    exports.ServiceLocatorService = ServiceLocatorService;

    ServiceLocatorService.??fac = function ServiceLocatorService_Factory(t) {
      return new (t || ServiceLocatorService)(i0.????inject(i1.HttpClient));
    };

    ServiceLocatorService.??prov = i0.????defineInjectable({
      token: ServiceLocatorService,
      factory: ServiceLocatorService.??fac
    });
    /*@__PURE__*/

    (function () {
      i0.??setClassMetadata(ServiceLocatorService, [{
        type: core_1.Injectable
      }], function () {
        return [{
          type: i1.HttpClient
        }];
      }, null);
    })();
    /***/

  },

  /***/
  "./src/environments/environment.ts":
  /*!*****************************************!*\
    !*** ./src/environments/environment.ts ***!
    \*****************************************/

  /*! no static exports found */

  /***/
  function srcEnvironmentsEnvironmentTs(module, exports, __webpack_require__) {
    "use strict"; // This file can be replaced during build by using the `fileReplacements` array.
    // `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
    // The list of file replacements can be found in `angular.json`.

    Object.defineProperty(exports, "__esModule", {
      value: true
    });
    exports.environment = {
      production: false
    };
    /*
     * For easier debugging in development mode, you can import the following file
     * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
     *
     * This import should be commented out in production mode because it will have a negative impact
     * on performance if an error is thrown.
     */
    // import 'zone.js/dist/zone-error';  // Included with Angular CLI.

    /***/
  },

  /***/
  "./src/main.ts":
  /*!*********************!*\
    !*** ./src/main.ts ***!
    \*********************/

  /*! no static exports found */

  /***/
  function srcMainTs(module, exports, __webpack_require__) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
      value: true
    });

    var core_1 = __webpack_require__(
    /*! @angular/core */
    "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");

    var environment_1 = __webpack_require__(
    /*! ./environments/environment */
    "./src/environments/environment.ts");

    var __NgCli_bootstrap_1 = __webpack_require__(
    /*! ./app/app.module */
    "./src/app/app.module.ts");

    var __NgCli_bootstrap_2 = __webpack_require__(
    /*! @angular/platform-browser */
    "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");

    if (environment_1.environment.production) {
      core_1.enableProdMode();
    }

    __NgCli_bootstrap_2.platformBrowser().bootstrapModule(__NgCli_bootstrap_1.AppModule)["catch"](function (err) {
      return console.error(err);
    });
    /***/

  },

  /***/
  0:
  /*!***************************!*\
    !*** multi ./src/main.ts ***!
    \***************************/

  /*! no static exports found */

  /***/
  function _(module, exports, __webpack_require__) {
    module.exports = __webpack_require__(
    /*! E:\DevUIArea\angular-product-setup\src\main.ts */
    "./src/main.ts");
    /***/
  }
}, [[0, "runtime", "vendor"]]]);
//# sourceMappingURL=main-es5.js.map