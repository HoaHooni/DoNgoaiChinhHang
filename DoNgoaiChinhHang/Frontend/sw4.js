'use strict';
var precacheConfig = [
    ["/js/details.js", "10024f32eaa5bfa5293546c7af5ecb88"],
    ["/js/add-script.js", "10025f32eaa5bfa5293546c7af5ecb88"],
    ["/js/script.js", "10026f32eaa5bfa5293546c7af5ecb88"],
    ["/js/jquery.elevatezoom.js", "10027f32eaa5bfa5293546c7af5ecb88"],
    ["/js/common.js", "10028f32eaa5bfa5293546c7af5ecb88"],
    ["/js/home.js", "10029f32eaa5bfa5293546c7af5ecb88"],
    ["/js/category.js", "10030f32eaa5bfa5293546c7af5ecb88"],
    ["/js/jquery.sticky.js", "10031f32eaa5bfa5293546c7af5ecb88"],
    ["/js/jquery-ui.min.js", "10032f32eaa5bfa5293546c7af5ecb88"],
    ["/js/push-notify.js", "10033f32eaa5bfa5293546c7af5ecb88"],
    ["/js/jquery.jcarousellite.js", "10034f32eaa5bfa5293546c7af5ecb88"],
    ["/js/jquery.fancybox.js", "10035f32eaa5bfa5293546c7af5ecb88"],
    ["/js/response.min.js", "10036f32eaa5bfa5293546c7af5ecb88"],
    ["/css/cart.min.css", "10037f32eaa5bfa5293546c7af5ecb88"],
    ["/css/category.css", "10038f32eaa5bfa5293546c7af5ecb88"],
    ["/css/detail.css", "10039f32eaa5bfa5293546c7af5ecb88"],
    ["/css/home.css", "10040f32eaa5bfa5293546c7af5ecb88"],
    ["/css/menu.css", "10041f32eaa5bfa5293546c7af5ecb88"],
    ["/css/owl-carousel.css", "10042f32eaa5bfa5293546c7af5ecb88"],
    ["/css/progift.css", "10043f32eaa5bfa5293546c7af5ecb88"],
    ["/css/push-notify.css", "10044f32eaa5bfa5293546c7af5ecb88"],
    ["/css/styles.css", "10045f32eaa5bfa5293546c7af5ecb88"]
];
var cacheName = 'sw-precache-v88-sw-precache-' + (self.registration ? self.registration.scope : '');
var ignoreUrlParametersMatching = [/^sA/];
var addDirectoryIndex = function(e, t) {
        var n = new URL(e);
        return "/" === n.pathname.slice(-1) && (n.pathname += t), n.toString()
    },
    createCacheKey = function(e, t, n, r) {
        var o = new URL(e);
        return r && o.toString().match(r) || (o.search += (o.search ? "&" : "") + encodeURIComponent(t) + "=" + encodeURIComponent(n)), o.toString()
    },
    isPathWhitelisted = function(e, t) {
        if (0 === e.length) return !0;
        var n = new URL(t).pathname;
        return e.some(function(e) {
            return n.match(e)
        })
    },
    stripIgnoredUrlParameters = function(e, t) {
        var n = new URL(e);
        return n.search = n.search.slice(1).split("&").map(function(e) {
            return e.split("=")
        }).filter(function(e) {
            return t.every(function(t) {
                return !t.test(e[0])
            })
        }).map(function(e) {
            return e.join("=")
        }).join("&"), n.toString()
    },
    hashParamName = "_sw-precache",
    urlsToCacheKeys = new Map(precacheConfig.map(function(e) {
        var t = e[0],
            n = e[1],
            r = new URL(t, self.location),
            o = createCacheKey(r, hashParamName, n, !1);
        return [r.toString(), o]
    }));

function setOfCachedUrls(e) {
    return e.keys().then(function(e) {
        return e.map(function(e) {
            return e.url
        })
    }).then(function(e) {
        return new Set(e)
    })
}
self.addEventListener("install", function(e) {
        e.waitUntil(caches.open(cacheName).then(function(e) {
            return setOfCachedUrls(e).then(function(t) {
                return Promise.all(Array.from(urlsToCacheKeys.values()).map(function(n) {
                    if (!t.has(n)) return e.add(new Request(n, {
                        credentials: "same-origin",
                        redirect: "follow"
                    }))
                }))
            })
        }).then(function() {
            return self.skipWaiting()
        }))
    }), self.addEventListener("activate", function(e) {
        var t = new Set(urlsToCacheKeys.values());
        e.waitUntil(caches.open(cacheName).then(function(e) {
            return e.keys().then(function(n) {
                return Promise.all(n.map(function(n) {
                    if (!t.has(n.url)) return e.delete(n)
                }))
            })
        }).then(function() {
            return self.clients.claim()
        }))
    }), self.addEventListener("fetch", function(e) {
        if ("GET" === e.request.method) {
            var t, n = stripIgnoredUrlParameters(e.request.url, ignoreUrlParametersMatching),
                r = "index.html";
            (t = urlsToCacheKeys.has(n)) || (n = addDirectoryIndex(n, r), t = urlsToCacheKeys.has(n));
            0, t && e.respondWith(caches.open(cacheName).then(function(e) {
                return e.match(urlsToCacheKeys.get(n)).then(function(e) {
                    if (e) return e;
                    throw Error("The cached response that was expected is missing.")
                })
            }).catch(function(t) {
                return console.warn('Couldn\'t serve response for "%s" from cache: %O', e.request.url, t), fetch(e.request)
            }))
        }
    }),
    function(e) {
        if ("object" == typeof exports && "undefined" != typeof module) module.exports = e();
        else if ("function" == typeof define && define.amd) define([], e);
        else {
            ("undefined" != typeof window ? window : "undefined" != typeof global ? global : "undefined" != typeof self ? self : this).toolbox = e()
        }
    }(function() {
        return function e(t, n, r) {
            function o(a, c) {
                if (!n[a]) {
                    if (!t[a]) {
                        var s = "function" == typeof require && require;
                        if (!c && s) return s(a, !0);
                        if (i) return i(a, !0);
                        var u = new Error("Cannot find module '" + a + "'");
                        throw u.code = "MODULE_NOT_FOUND", u
                    }
                    var h = n[a] = {
                        exports: {}
                    };
                    t[a][0].call(h.exports, function(e) {
                        var n = t[a][1][e];
                        return o(n || e)
                    }, h, h.exports, e, t, n, r)
                }
                return n[a].exports
            }
            for (var i = "function" == typeof require && require, a = 0; a < r.length; a++) o(r[a]);
            return o
        }({
            1: [function(e, t, n) {
                "use strict";

                function r(e, t) {
                    ((t = t || {}).debug || c.debug) && console.log("[sw-toolbox] " + e)
                }

                function o(e) {
                    var t;
                    return e && e.cache && (t = e.cache.name), t = t || c.cache.name, caches.open(t)
                }

                function i(e) {
                    var t = Array.isArray(e);
                    if (t && e.forEach(function(e) {
                            "string" == typeof e || e instanceof Request || (t = !1)
                        }), !t) throw new TypeError("The precache method expects either an array of strings and/or Requests or a Promise that resolves to an array of strings and/or Requests.");
                    return e
                }
                var a, c = e("./options"),
                    s = e("./idb-cache-expiration");
                t.exports = {
                    debug: r,
                    fetchAndCache: function(e, t) {
                        var n = (t = t || {}).successResponses || c.successResponses;
                        return fetch(e.clone()).then(function(i) {
                            return "GET" === e.method && n.test(i.status) && o(t).then(function(n) {
                                n.put(e, i).then(function() {
                                    var o, i = t.cache || c.cache;
                                    (i.maxEntries || i.maxAgeSeconds) && i.name && (o = function(e, t, n) {
                                        var o = e.url,
                                            i = n.maxAgeSeconds,
                                            a = n.maxEntries,
                                            c = n.name,
                                            u = Date.now();
                                        return r("Updating LRU order for " + o + ". Max entries is " + a + ", max age is " + i), s.getDb(c).then(function(e) {
                                            return s.setTimestampForUrl(e, o, u)
                                        }).then(function(e) {
                                            return s.expireEntries(e, a, i, u)
                                        }).then(function(e) {
                                            r("Successfully updated IDB.");
                                            var n = e.map(function(e) {
                                                return t.delete(e)
                                            });
                                            return Promise.all(n).then(function() {
                                                r("Done with cache cleanup.")
                                            })
                                        }).catch(function(e) {
                                            r(e)
                                        })
                                    }.bind(null, e, n, i), a = a ? a.then(o) : o())
                                })
                            }), i.clone()
                        })
                    },
                    openCache: o,
                    renameCache: function(e, t, n) {
                        return r("Renaming cache: [" + e + "] to [" + t + "]", n), caches.delete(t).then(function() {
                            return Promise.all([caches.open(e), caches.open(t)]).then(function(t) {
                                var n = t[0],
                                    r = t[1];
                                return n.keys().then(function(e) {
                                    return Promise.all(e.map(function(e) {
                                        return n.match(e).then(function(t) {
                                            return r.put(e, t)
                                        })
                                    }))
                                }).then(function() {
                                    return caches.delete(e)
                                })
                            })
                        })
                    },
                    cache: function(e, t) {
                        return o(t).then(function(t) {
                            return t.add(e)
                        })
                    },
                    uncache: function(e, t) {
                        return o(t).then(function(t) {
                            return t.delete(e)
                        })
                    },
                    precache: function(e) {
                        e instanceof Promise || i(e), c.preCacheItems = c.preCacheItems.concat(e)
                    },
                    validatePrecacheInput: i,
                    isResponseFresh: function(e, t, n) {
                        if (!e) return !1;
                        if (t) {
                            var r = e.headers.get("date");
                            if (r && new Date(r).getTime() + 1e3 * t < n) return !1
                        }
                        return !0
                    }
                }
            }, {
                "./idb-cache-expiration": 2,
                "./options": 4
            }],
            2: [function(e, t, n) {
                "use strict";
                var r = "sw-toolbox-",
                    o = 1,
                    i = "store",
                    a = "url",
                    c = "timestamp",
                    s = {};
                t.exports = {
                    getDb: function(e) {
                        return e in s || (s[e] = (t = e, new Promise(function(e, n) {
                            var s = indexedDB.open(r + t, o);
                            s.onupgradeneeded = function() {
                                s.result.createObjectStore(i, {
                                    keyPath: a
                                }).createIndex(c, c, {
                                    unique: !1
                                })
                            }, s.onsuccess = function() {
                                e(s.result)
                            }, s.onerror = function() {
                                n(s.error)
                            }
                        }))), s[e];
                        var t
                    },
                    setTimestampForUrl: function(e, t, n) {
                        return new Promise(function(r, o) {
                            var a = e.transaction(i, "readwrite");
                            a.objectStore(i).put({
                                url: t,
                                timestamp: n
                            }), a.oncomplete = function() {
                                r(e)
                            }, a.onabort = function() {
                                o(a.error)
                            }
                        })
                    },
                    expireEntries: function(e, t, n, r) {
                        return (o = e, s = n, u = r, s ? new Promise(function(e, t) {
                            var n = 1e3 * s,
                                r = [],
                                h = o.transaction(i, "readwrite"),
                                f = h.objectStore(i);
                            f.index(c).openCursor().onsuccess = function(e) {
                                var t = e.target.result;
                                if (t && u - n > t.value[c]) {
                                    var o = t.value[a];
                                    r.push(o), f.delete(o), t.continue()
                                }
                            }, h.oncomplete = function() {
                                e(r)
                            }, h.onabort = t
                        }) : Promise.resolve([])).then(function(n) {
                            return (r = e, o = t, o ? new Promise(function(e, t) {
                                var n = [],
                                    s = r.transaction(i, "readwrite"),
                                    u = s.objectStore(i),
                                    h = u.index(c),
                                    f = h.count();
                                h.count().onsuccess = function() {
                                    var e = f.result;
                                    e > o && (h.openCursor().onsuccess = function(t) {
                                        var r = t.target.result;
                                        if (r) {
                                            var i = r.value[a];
                                            n.push(i), u.delete(i), e - n.length > o && r.continue()
                                        }
                                    })
                                }, s.oncomplete = function() {
                                    e(n)
                                }, s.onabort = t
                            }) : Promise.resolve([])).then(function(e) {
                                return n.concat(e)
                            });
                            var r, o
                        });
                        var o, s, u
                    }
                }
            }, {}],
            3: [function(e, t, n) {
                "use strict";

                function r(e) {
                    return e.reduce(function(e, t) {
                        return e.concat(t)
                    }, [])
                }
                e("serviceworker-cache-polyfill");
                var o = e("./helpers"),
                    i = e("./router"),
                    a = e("./options");
                t.exports = {
                    fetchListener: function(e) {
                        var t = i.match(e.request);
                        t ? e.respondWith(t(e.request)) : i.default && "GET" === e.request.method && 0 === e.request.url.indexOf("http") && e.respondWith(i.default(e.request))
                    },
                    activateListener: function(e) {
                        o.debug("activate event fired");
                        var t = a.cache.name + "$$$inactive$$$";
                        e.waitUntil(o.renameCache(t, a.cache.name))
                    },
                    installListener: function(e) {
                        var t = a.cache.name + "$$$inactive$$$";
                        o.debug("install event fired"), o.debug("creating cache [" + t + "]"), e.waitUntil(o.openCache({
                            cache: {
                                name: t
                            }
                        }).then(function(e) {
                            return Promise.all(a.preCacheItems).then(r).then(o.validatePrecacheInput).then(function(t) {
                                return o.debug("preCache list: " + (t.join(", ") || "(none)")), e.addAll(t)
                            })
                        }))
                    }
                }
            }, {
                "./helpers": 1,
                "./options": 4,
                "./router": 6,
                "serviceworker-cache-polyfill": 16
            }],
            4: [function(e, t, n) {
                "use strict";
                var r;
                r = self.registration ? self.registration.scope : self.scope || new URL("./", self.location).href, t.exports = {
                    cache: {
                        name: "$$$toolbox-cache$$$" + r + "$$$",
                        maxAgeSeconds: null,
                        maxEntries: null
                    },
                    debug: !1,
                    networkTimeoutSeconds: null,
                    preCacheItems: [],
                    successResponses: /^0|([123]\d\d)|(40[14567])|410$/
                }
            }, {}],
            5: [function(e, t, n) {
                "use strict";
                var r = new URL("./", self.location).pathname,
                    o = e("path-to-regexp"),
                    i = function(e, t, n, i) {
                        t instanceof RegExp ? this.fullUrlRegExp = t : (0 !== t.indexOf("/") && (t = r + t), this.keys = [], this.regexp = o(t, this.keys)), this.method = e, this.options = i, this.handler = n
                    };
                i.prototype.makeHandler = function(e) {
                    var t;
                    if (this.regexp) {
                        var n = this.regexp.exec(e);
                        t = {}, this.keys.forEach(function(e, r) {
                            t[e.name] = n[r + 1]
                        })
                    }
                    return function(e) {
                        return this.handler(e, t, this.options)
                    }.bind(this)
                }, t.exports = i
            }, {
                "path-to-regexp": 15
            }],
            6: [function(e, t, n) {
                "use strict";
                var r = e("./route"),
                    o = e("./helpers"),
                    i = function(e, t) {
                        for (var n = e.entries(), r = n.next(), o = []; !r.done;) {
                            new RegExp(r.value[0]).test(t) && o.push(r.value[1]), r = n.next()
                        }
                        return o
                    },
                    a = function() {
                        this.routes = new Map, this.routes.set(RegExp, new Map), this.default = null
                    };
                ["get", "post", "put", "delete", "head", "any"].forEach(function(e) {
                    a.prototype[e] = function(t, n, r) {
                        return this.add(e, t, n, r)
                    }
                }), a.prototype.add = function(e, t, n, i) {
                    var a;
                    i = i || {}, t instanceof RegExp ? a = RegExp : a = (a = i.origin || self.location.origin) instanceof RegExp ? a.source : a.replace(/[-\/\\^$*+?.()|[\]{}]/g, "\\$&"), e = e.toLowerCase();
                    var c = new r(e, t, n, i);
                    this.routes.has(a) || this.routes.set(a, new Map);
                    var s = this.routes.get(a);
                    s.has(e) || s.set(e, new Map);
                    var u = s.get(e),
                        h = c.regexp || c.fullUrlRegExp;
                    u.has(h.source) && o.debug('"' + t + '" resolves to same regex as existing route.'), u.set(h.source, c)
                }, a.prototype.matchMethod = function(e, t) {
                    var n = new URL(t),
                        r = n.origin,
                        o = n.pathname;
                    return this._match(e, i(this.routes, r), o) || this._match(e, [this.routes.get(RegExp)], t)
                }, a.prototype._match = function(e, t, n) {
                    if (0 === t.length) return null;
                    for (var r = 0; r < t.length; r++) {
                        var o = t[r],
                            a = o && o.get(e.toLowerCase());
                        if (a) {
                            var c = i(a, n);
                            if (c.length > 0) return c[0].makeHandler(n)
                        }
                    }
                    return null
                }, a.prototype.match = function(e) {
                    return this.matchMethod(e.method, e.url) || this.matchMethod("any", e.url)
                }, t.exports = new a
            }, {
                "./helpers": 1,
                "./route": 5
            }],
            7: [function(e, t, n) {
                "use strict";
                var r = e("../options"),
                    o = e("../helpers");
                t.exports = function(e, t, n) {
                    return n = n || {}, o.debug("Strategy: cache first [" + e.url + "]", n), o.openCache(n).then(function(t) {
                        return t.match(e).then(function(t) {
                            var i = n.cache || r.cache,
                                a = Date.now();
                            return o.isResponseFresh(t, i.maxAgeSeconds, a) ? t : o.fetchAndCache(e, n)
                        })
                    })
                }
            }, {
                "../helpers": 1,
                "../options": 4
            }],
            8: [function(e, t, n) {
                "use strict";
                var r = e("../options"),
                    o = e("../helpers");
                t.exports = function(e, t, n) {
                    return n = n || {}, o.debug("Strategy: cache only [" + e.url + "]", n), o.openCache(n).then(function(t) {
                        return t.match(e).then(function(e) {
                            var t = n.cache || r.cache,
                                i = Date.now();
                            if (o.isResponseFresh(e, t.maxAgeSeconds, i)) return e
                        })
                    })
                }
            }, {
                "../helpers": 1,
                "../options": 4
            }],
            9: [function(e, t, n) {
                "use strict";
                var r = e("../helpers"),
                    o = e("./cacheOnly");
                t.exports = function(e, t, n) {
                    return r.debug("Strategy: fastest [" + e.url + "]", n), new Promise(function(i, a) {
                        var c = !1,
                            s = [],
                            u = function(e) {
                                s.push(e.toString()), c ? a(new Error('Both cache and network failed: "' + s.join('", "') + '"')) : c = !0
                            },
                            h = function(e) {
                                e instanceof Response ? i(e) : u("No result returned")
                            };
                        r.fetchAndCache(e.clone(), n).then(h, u), o(e, t, n).then(h, u)
                    })
                }
            }, {
                "../helpers": 1,
                "./cacheOnly": 8
            }],
            10: [function(e, t, n) {
                t.exports = {
                    networkOnly: e("./networkOnly"),
                    networkFirst: e("./networkFirst"),
                    cacheOnly: e("./cacheOnly"),
                    cacheFirst: e("./cacheFirst"),
                    fastest: e("./fastest")
                }
            }, {
                "./cacheFirst": 7,
                "./cacheOnly": 8,
                "./fastest": 9,
                "./networkFirst": 11,
                "./networkOnly": 12
            }],
            11: [function(e, t, n) {
                "use strict";
                var r = e("../options"),
                    o = e("../helpers");
                t.exports = function(e, t, n) {
                    var i = (n = n || {}).successResponses || r.successResponses,
                        a = n.networkTimeoutSeconds || r.networkTimeoutSeconds;
                    return o.debug("Strategy: network first [" + e.url + "]", n), o.openCache(n).then(function(t) {
                        var c, s, u = [];
                        if (a) {
                            var h = new Promise(function(i) {
                                c = setTimeout(function() {
                                    t.match(e).then(function(e) {
                                        var t = n.cache || r.cache,
                                            a = Date.now(),
                                            c = t.maxAgeSeconds;
                                        o.isResponseFresh(e, c, a) && i(e)
                                    })
                                }, 1e3 * a)
                            });
                            u.push(h)
                        }
                        var f = o.fetchAndCache(e, n).then(function(e) {
                            if (c && clearTimeout(c), i.test(e.status)) return e;
                            throw o.debug("Response was an HTTP error: " + e.statusText, n), s = e, new Error("Bad response")
                        }).catch(function(r) {
                            return o.debug("Network or response error, fallback to cache [" + e.url + "]", n), t.match(e).then(function(e) {
                                if (e) return e;
                                if (s) return s;
                                throw r
                            })
                        });
                        return u.push(f), Promise.race(u)
                    })
                }
            }, {
                "../helpers": 1,
                "../options": 4
            }],
            12: [function(e, t, n) {
                "use strict";
                var r = e("../helpers");
                t.exports = function(e, t, n) {
                    return r.debug("Strategy: network only [" + e.url + "]", n), fetch(e)
                }
            }, {
                "../helpers": 1
            }],
            13: [function(e, t, n) {
                "use strict";
                var r = e("./options"),
                    o = e("./router"),
                    i = e("./helpers"),
                    a = e("./strategies"),
                    c = e("./listeners");
                i.debug("Service Worker Toolbox is loading"), self.addEventListener("install", c.installListener), self.addEventListener("activate", c.activateListener), self.addEventListener("fetch", c.fetchListener), t.exports = {
                    networkOnly: a.networkOnly,
                    networkFirst: a.networkFirst,
                    cacheOnly: a.cacheOnly,
                    cacheFirst: a.cacheFirst,
                    fastest: a.fastest,
                    router: o,
                    options: r,
                    cache: i.cache,
                    uncache: i.uncache,
                    precache: i.precache
                }
            }, {
                "./helpers": 1,
                "./listeners": 3,
                "./options": 4,
                "./router": 6,
                "./strategies": 10
            }],
            14: [function(e, t, n) {
                t.exports = Array.isArray || function(e) {
                    return "[object Array]" == Object.prototype.toString.call(e)
                }
            }, {}],
            15: [function(e, t, n) {
                function r(e, t) {
                    for (var n, r = [], o = 0, i = 0, c = "", s = t && t.delimiter || "/"; null != (n = l.exec(e));) {
                        var u = n[0],
                            h = n[1],
                            f = n.index;
                        if (c += e.slice(i, f), i = f + u.length, h) c += h[1];
                        else {
                            var p = e[i],
                                d = n[2],
                                m = n[3],
                                g = n[4],
                                v = n[5],
                                w = n[6],
                                x = n[7];
                            c && (r.push(c), c = "");
                            var y = null != d && null != p && p !== d,
                                b = "+" === w || "*" === w,
                                E = "?" === w || "*" === w,
                                R = n[2] || s,
                                C = g || v;
                            r.push({
                                name: m || o++,
                                prefix: d || "",
                                delimiter: R,
                                optional: E,
                                repeat: b,
                                partial: y,
                                asterisk: !!x,
                                pattern: C ? (k = C, k.replace(/([=!:$\/()])/g, "\\$1")) : x ? ".*" : "[^" + a(R) + "]+?"
                            })
                        }
                    }
                    var k;
                    return i < e.length && (c += e.substr(i)), c && r.push(c), r
                }

                function o(e) {
                    return encodeURI(e).replace(/[\/?#]/g, function(e) {
                        return "%" + e.charCodeAt(0).toString(16).toUpperCase()
                    })
                }

                function i(e) {
                    for (var t = new Array(e.length), n = 0; n < e.length; n++) "object" == typeof e[n] && (t[n] = new RegExp("^(?:" + e[n].pattern + ")$"));
                    return function(n, r) {
                        for (var i = "", a = n || {}, c = (r || {}).pretty ? o : encodeURIComponent, s = 0; s < e.length; s++) {
                            var u = e[s];
                            if ("string" != typeof u) {
                                var h, l = a[u.name];
                                if (null == l) {
                                    if (u.optional) {
                                        u.partial && (i += u.prefix);
                                        continue
                                    }
                                    throw new TypeError('Expected "' + u.name + '" to be defined')
                                }
                                if (f(l)) {
                                    if (!u.repeat) throw new TypeError('Expected "' + u.name + '" to not repeat, but received `' + JSON.stringify(l) + "`");
                                    if (0 === l.length) {
                                        if (u.optional) continue;
                                        throw new TypeError('Expected "' + u.name + '" to not be empty')
                                    }
                                    for (var p = 0; p < l.length; p++) {
                                        if (h = c(l[p]), !t[s].test(h)) throw new TypeError('Expected all "' + u.name + '" to match "' + u.pattern + '", but received `' + JSON.stringify(h) + "`");
                                        i += (0 === p ? u.prefix : u.delimiter) + h
                                    }
                                } else {
                                    if (h = u.asterisk ? encodeURI(l).replace(/[?#]/g, function(e) {
                                            return "%" + e.charCodeAt(0).toString(16).toUpperCase()
                                        }) : c(l), !t[s].test(h)) throw new TypeError('Expected "' + u.name + '" to match "' + u.pattern + '", but received "' + h + '"');
                                    i += u.prefix + h
                                }
                            } else i += u
                        }
                        return i
                    }
                }

                function a(e) {
                    return e.replace(/([.+*?=^!:${}()[\]|\/\\])/g, "\\$1")
                }

                function c(e, t) {
                    return e.keys = t, e
                }

                function s(e) {
                    return e.sensitive ? "" : "i"
                }

                function u(e, t, n) {
                    f(t) || (n = t || n, t = []);
                    for (var r = (n = n || {}).strict, o = !1 !== n.end, i = "", u = 0; u < e.length; u++) {
                        var h = e[u];
                        if ("string" == typeof h) i += a(h);
                        else {
                            var l = a(h.prefix),
                                p = "(?:" + h.pattern + ")";
                            t.push(h), h.repeat && (p += "(?:" + l + p + ")*"), i += p = h.optional ? h.partial ? l + "(" + p + ")?" : "(?:" + l + "(" + p + "))?" : l + "(" + p + ")"
                        }
                    }
                    var d = a(n.delimiter || "/"),
                        m = i.slice(-d.length) === d;
                    return r || (i = (m ? i.slice(0, -d.length) : i) + "(?:" + d + "(?=$))?"), i += o ? "$" : r && m ? "" : "(?=" + d + "|$)", c(new RegExp("^" + i, s(n)), t)
                }

                function h(e, t, n) {
                    return f(t) || (n = t || n, t = []), n = n || {}, e instanceof RegExp ? function(e, t) {
                        var n = e.source.match(/\((?!\?)/g);
                        if (n)
                            for (var r = 0; r < n.length; r++) t.push({
                                name: r,
                                prefix: null,
                                delimiter: null,
                                optional: !1,
                                repeat: !1,
                                partial: !1,
                                asterisk: !1,
                                pattern: null
                            });
                        return c(e, t)
                    }(e, t) : f(e) ? function(e, t, n) {
                        for (var r = [], o = 0; o < e.length; o++) r.push(h(e[o], t, n).source);
                        return c(new RegExp("(?:" + r.join("|") + ")", s(n)), t)
                    }(e, t, n) : (o = t, u(r(e, i = n), o, i));
                    var o, i
                }
                var f = e("isarray");
                t.exports = h, t.exports.parse = r, t.exports.compile = function(e, t) {
                    return i(r(e, t))
                }, t.exports.tokensToFunction = i, t.exports.tokensToRegExp = u;
                var l = new RegExp(["(\\\\.)", "([\\/.])?(?:(?:\\:(\\w+)(?:\\(((?:\\\\.|[^\\\\()])+)\\))?|\\(((?:\\\\.|[^\\\\()])+)\\))([+*?])?|(\\*))"].join("|"), "g")
            }, {
                isarray: 14
            }],
            16: [function(e, t, n) {
                ! function() {
                    var e = Cache.prototype.addAll,
                        t = navigator.userAgent.match(/(Firefox|Chrome)\/(\d+\.)/);
                    if (t) var n = t[1],
                        r = parseInt(t[2]);
                    e && (!t || "Firefox" === n && r >= 46 || "Chrome" === n && r >= 50) || (Cache.prototype.addAll = function(e) {
                        function t(e) {
                            this.name = "NetworkError", this.code = 19, this.message = e
                        }
                        var n = this;
                        return t.prototype = Object.create(Error.prototype), Promise.resolve().then(function() {
                            if (arguments.length < 1) throw new TypeError;
                            return e = e.map(function(e) {
                                return e instanceof Request ? e : String(e)
                            }), Promise.all(e.map(function(e) {
                                "string" == typeof e && (e = new Request(e));
                                var n = new URL(e.url).protocol;
                                if ("http:" !== n && "https:" !== n) throw new t("Invalid scheme");
                                return fetch(e.clone())
                            }))
                        }).then(function(r) {
                            if (r.some(function(e) {
                                    return !e.ok
                                })) throw new t("Incorrect response status");
                            return Promise.all(r.map(function(t, r) {
                                return n.put(e[r], t)
                            }))
                        }).then(function() {})
                    }, Cache.prototype.add = function(e) {
                        return this.addAll([e])
                    })
                }()
            }, {}]
        }, {}, [13])(13)
    }), toolbox.router.get(/^https?:\/\/(dongoaichinhhang\.(com))\/images\//, toolbox.fastest, {});