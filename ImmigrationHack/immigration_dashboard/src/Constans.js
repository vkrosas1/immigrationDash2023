export const BASE_URL = 'https://localhost:44368/ImmigrationDashboard/';
export const USER_ID = '1';
export const STATUSES = {
    NOT_STARTED: {
        key: 'NOT_STARTED',
        value: 'Not Started',
        className: 'white-bis',
        order: 3
    },
    IN_PROGRESS: {
        key: 'IN_PROGRESS',
        value: 'In Progress',
        className: 'link-light',
        order: 2
    },
    IN_REVIEW: {
        key: 'IN_REVIEW',
        value: 'In Review',
        className: 'info',
        order: 1
    },
    COMPLETED: {
        key: 'COMPLETED',
        value: 'Completed',
        className: 'success',
        order: 0
    }
}
export const TEMP_USER = {
    id: 1,
    paths: [
        "F1 Visa Path"
    ]
}