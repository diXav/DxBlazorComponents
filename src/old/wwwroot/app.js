let outsideClickElements = []

export function focus(id)
{
    const element = document.getElementById(id);
    if (element) element.focus();
}

export function clickButtonWithId(buttonId)
{
    const button = document.getElementById(buttonId)

    if (button)
        button.click()
    else
        console.warn('failed to click button, button not found, id = ' + buttonId)
}

export function addOutsideClickListener(dotnetRef, callbackName, elementId)
{
    const element = document.getElementById(elementId);

    if (!element)
    {
        console.warn('element with id ' + elementId + ' not found')
        return
    }

    outsideClickElements.push
    (
        {
            dotnetRef: dotnetRef,
            callbackName: callbackName,
            elementId: elementId,
            element: element
        }
    )
}

export function removeOutsideClickListener(elementId)
{
    const index = outsideClickElements.findIndex(x => x.elementId == elementId)
    
    if (index >= 0)
        outsideClickElements.splice(index, 1)
}

document.addEventListener('click', e =>
{
    outsideClickElements.forEach(x =>
    {
        if (!x.element.contains(e.target))
                x.dotnetRef.invokeMethodAsync(x.callbackName)
    })
})

export function getDarkMode()
{
    return localStorage.getItem('darkMode') === 'true';
}

export function toggleDarkMode()
{
    const newDarkMode = !getDarkMode();
    localStorage.setItem('darkMode', newDarkMode);
    
    if (newDarkMode)
        document.getElementsByTagName('html')[0].classList.add('dark');
    else
        document.getElementsByTagName('html')[0].classList.remove('dark');

    if ('dx' in window && 'updateMapStyle' in window.dx)
        window.dx.updateMapStyle();

    return newDarkMode;
}