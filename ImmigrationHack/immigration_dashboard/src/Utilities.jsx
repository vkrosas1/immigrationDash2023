import { STATUSES } from "./Constants"
export const sortStatuses = (x, y) => {
    const xOrder = x.status ? STATUSES[x.status].order : Object.keys(STATUSES).length
    const yOrder = y.status ? STATUSES[y.status].order : Object.keys(STATUSES).length
    if (xOrder < yOrder) {
        return -1;
    }
    else if (xOrder > yOrder) {
        return 1;
    }
    else {
        return 0;
    }
}