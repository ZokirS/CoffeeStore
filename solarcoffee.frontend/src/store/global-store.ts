import {make} from 'vuex-pathify';
import { IInventoryTimeLine } from '../types/InventoryGraph';
import { InventoryService } from '../services/inventory-service';

class GlobalStore{
snapshotTimeLine: IInventoryTimeLine = {
    productInventorySnapshots: [],
    timeline: []
};

isTimeBuilt: boolean = false;
}

const state=new GlobalStore();

const mutations = make.mutations(state);

const actions={
    async assignSnapshots({commit}){
        const inventoryService = new InventoryService();
        let res = await inventoryService.getSnapshotHistory();

        let timeline: IInventoryTimeLine ={
            productInventorySnapshots: res.productInventorySnapshots,
            timeline: res.timeline
        };

        commit('SET_SNAPSHOT_TIMELINE', timeline);
        commit('SET_IS_TIMELINE_BUILT', true);
    },
};

const getters={};
export default{
state,
mutations,
actions,
getters
}