export namespace File {

    const cacheName = 'offline-cache-assets';

    export let load = function (fileName: string): Promise<string> {

        return caches.open(cacheName).then(cache => {
            return cache.match(fileName).then(response => {
                if (response) {
                    // Retorna texto da resposta
                    return response.text();
                }
                else {
                    return cache.add(fileName).then(() => {
                        return cache.match(fileName).then(cache_response => {
                            if (cache_response) {
                                // Retorna texto da resposta
                                return cache_response.text();
                            }
                        });
                    });
                }
            })
        });

        //// Download do ficheiro
        //return fetch(fileName).then(response => {
        //    if (response.ok) {
        //        // Retorna texto da resposta
        //        return response.text();
        //    }
        //});
    }
}