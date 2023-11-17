export var File;
(function (File) {
    const cacheName = 'offline-cache-assets';
    File.load = function (fileName) {
        return caches.open(cacheName).then(cache => {
            return cache.match(fileName).then(response => {
                if (response) {
                    return response.text();
                }
                else {
                    return cache.add(fileName).then(() => {
                        return cache.match(fileName).then(cache_response => {
                            if (cache_response) {
                                return cache_response.text();
                            }
                        });
                    });
                }
            });
        });
    };
})(File || (File = {}));
