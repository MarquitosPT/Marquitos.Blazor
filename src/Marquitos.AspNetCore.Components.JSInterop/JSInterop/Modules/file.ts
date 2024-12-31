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

    export let downloadFileFromBase64 = function (fileName: string, base64: string): void {
        const blob = base64ToBlob(base64);
        const url = URL.createObjectURL(blob);

        const anchorElement = document.createElement('a');
        anchorElement.href = url;
        anchorElement.download = fileName ?? '';
        anchorElement.click();
        anchorElement.remove();

        URL.revokeObjectURL(url);
    }

    function base64ToBlob(base64: string): Blob {
        const byteCharacters = atob(base64);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);
        return new Blob([byteArray]);
    }
}


