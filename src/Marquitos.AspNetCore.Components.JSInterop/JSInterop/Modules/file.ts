﻿export namespace File {

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
    }

    export let downloadFileFromStream = async function (fileName: string, contentStreamReference: any): Promise<void> {
        const arrayBuffer = await contentStreamReference.arrayBuffer();
        const blob = new Blob([arrayBuffer]);
        const url = URL.createObjectURL(blob);

        const anchorElement = document.createElement('a');
        anchorElement.href = url;
        anchorElement.download = fileName ?? '';
        anchorElement.click();
        anchorElement.remove();

        URL.revokeObjectURL(url);
    }
}