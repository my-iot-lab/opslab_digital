<template>
	<div class="sys-formDes-container">
		<v-form-designer ref="vFormDesignRef"></v-form-designer>
	</div>
</template>

<script lang="ts">
import { toRefs, reactive, defineComponent, ref } from 'vue';

export default defineComponent({
	name: 'sysFormDes',
	components: {},
	setup() {
		const vFormDesignRef = ref(null);
		const state = reactive({
			loading: false,
		});

		return {
			vFormDesignRef,
			...toRefs(state),
		};
	},
});
</script>

<style lang="scss" scoped>
body {
	margin: 0; // 去除页面垂直滚动条
}
</style>
